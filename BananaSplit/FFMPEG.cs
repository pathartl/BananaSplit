using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BananaSplit
{
    public class FFMPEG
    {
        private Process process { get; set; }

        public FFMPEG()
        {
            process = new Process();

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.FileName = "ffmpeg.exe";
            process.StartInfo.CreateNoWindow = true;
        }

        public bool IsMatroska(string filePath, DataReceivedEventHandler outputHandler)
        {
            process.StartInfo.FileName = "ffprobe.exe";
            process.StartInfo.Arguments = $"\"{filePath}\"";

            var output = "";
            DataReceivedEventHandler handler = (s, evt) =>
            {
                output += evt.Data + "\n"; outputHandler(s, evt);
            };
            process.ErrorDataReceived += handler;

            process.Start();
            process.BeginErrorReadLine();

            process.WaitForExit();
            process.ErrorDataReceived -= handler;
            process.CancelErrorRead();

            string pattern = @"^Input #\d+, matroska";

            Regex regex = new Regex(pattern, RegexOptions.Multiline);

            return regex.IsMatch(output);
        }

        public TimeSpan GetDuration(string filePath, DataReceivedEventHandler outputHandler)
        {
            TimeSpan duration = new TimeSpan();

            process.StartInfo.FileName = "ffprobe.exe";
            process.StartInfo.Arguments = $"\"{filePath}\"";
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.RedirectStandardError = true;

            var output = "";
            DataReceivedEventHandler handler = (s, evt) =>
            {
                output += evt.Data + "\n"; outputHandler(s, evt);
            };
            process.ErrorDataReceived += handler;

            process.Start();
            process.BeginErrorReadLine();

            process.WaitForExit();
            process.ErrorDataReceived -= handler;
            process.CancelErrorRead();

            string pattern = @"^\s+Duration: (?<duration>\d+(?:.\d+)*)";

            Regex regex = new Regex(pattern, RegexOptions.Multiline);

            if (regex.IsMatch(output))
            {
                var durationString = regex.Match(output).Groups["duration"].Value;
                TimeSpan.TryParse(durationString, out duration);
            }

            return duration;
        }

        public byte[] ExtractFrame(string filePath, TimeSpan time, DataReceivedEventHandler outputHandler)
        {
            var timespan = String.Format("{0:D2}:{1:D2}:{2:D2}.{3}", time.Hours, time.Minutes, time.Seconds, time.Milliseconds);

            process.StartInfo.FileName = "ffmpeg.exe";
            process.StartInfo.Arguments = $"-ss {timespan} -i \"{filePath}\" -vframes 1 -c:v png -f image2pipe -";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            // ffmpeg uses stderr for some reason
            DataReceivedEventHandler handler = (s, evt) => outputHandler(s, evt);
            process.ErrorDataReceived += handler;

            process.Start();
            process.BeginErrorReadLine();

            using (MemoryStream ms = new MemoryStream())
            {
                process.StandardOutput.BaseStream.CopyTo(ms);

                process.WaitForExit();
                process.CancelErrorRead();
                process.ErrorDataReceived -= handler;

                return ms.ToArray();
            }
        }


        public void EncodeSegments(string source, string destination, string arguments, Segment segment, DataReceivedEventHandler outputHandler)
        {
            arguments = arguments.Replace("{source}", source);
            arguments = arguments.Replace("{destination}", destination);
            arguments = arguments.Replace("{start}", String.Format("{0:D2}:{1:D2}:{2:D2}.{3}", segment.Start.Hours, segment.Start.Minutes, segment.Start.Seconds, segment.Start.Milliseconds));
            arguments = arguments.Replace("{end}", String.Format("{0:D2}:{1:D2}:{2:D2}.{3}", segment.End.Hours, segment.End.Minutes, segment.End.Seconds, segment.End.Milliseconds));
            arguments = arguments.Replace("{duration}", String.Format("{0:D2}:{1:D2}:{2:D2}.{3}", segment.Duration.Hours, segment.Duration.Minutes, segment.Duration.Seconds, segment.Duration.Milliseconds));

            process.StartInfo.FileName = "ffmpeg.exe";
            process.StartInfo.Arguments = arguments;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.RedirectStandardError = true;

            // ffmpeg uses stderr for some reason
            DataReceivedEventHandler handler = (s, evt) => outputHandler(s, evt);
            process.ErrorDataReceived += handler;
            process.Start();
            process.BeginErrorReadLine();

            process.WaitForExit();
            process.ErrorDataReceived -= handler;
            process.CancelErrorRead();
        }

        public ICollection<BlackFrame> DetectBlackFrameIntervals(string filePath, double blackFrameDuration, double blackFrameThreshold, double blackFramePixelThreshold, DataReceivedEventHandler outputHandler)
        {
            var frames = new List<BlackFrame>();

            process.StartInfo.FileName = "ffmpeg.exe";
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.Arguments = $"-i \"{filePath}\" -vf blackdetect=d={blackFrameDuration}:pic_th={blackFrameThreshold}:pix_th={blackFramePixelThreshold} -an -f null -y /NUL";
            //process.StartInfo.Arguments = $"-i \"{filePath}\" -vf blackframe -f null -y /NUL";

            // ffmpeg uses stderr for some reason
            var output = "";
            DataReceivedEventHandler handler = (s, evt) =>
            {
                output += evt.Data + "\n"; outputHandler(s, evt);
            };
            process.ErrorDataReceived += handler;

            process.Start();
            process.BeginErrorReadLine();

            process.WaitForExit();
            process.ErrorDataReceived -= handler;
            process.CancelErrorRead();

            string pattern = @"(?:blackdetect.+)(?:black_start:)(?<start>\d+(?:.\d+)*) (?:black_end:)(?<end>\d+(?:.\d+)*) (?:black_duration:)(?<duration>\d+(?:.\d+)*)";

            Regex regex = new Regex(pattern, RegexOptions.Multiline);

            var matches = regex.Matches(output);

            foreach (Match match in matches)
            {
                try
                {
                    var frame = new BlackFrame();
                    decimal start;
                    decimal end;
                    decimal duration;

                    Decimal.TryParse(match.Groups["start"].Value, out start);
                    Decimal.TryParse(match.Groups["end"].Value, out end);
                    Decimal.TryParse(match.Groups["duration"].Value, out duration);

                    frame.Start = TimeSpan.FromSeconds((double)start);
                    frame.End = TimeSpan.FromSeconds((double)end);
                    frame.Duration = TimeSpan.FromSeconds((double)duration);
                    frame.Marker = frame.GetMiddle();

                    frames.Add(frame);
                }
                catch { }
            }

            return frames;
        }

        public ICollection<BlackFrame> DetectBlackFrames(string filePath, DataReceivedEventHandler outputHandler)
        {
            var frames = new List<BlackFrame>();

            process.StartInfo.FileName = "ffmpeg.exe";
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.Arguments = $"-i \"{filePath}\" -vf blackframe -f null -y /NUL";

            // ffmpeg uses stderr for some reason
            var output = "";
            DataReceivedEventHandler handler = (s, evt) =>
            {
                output += evt.Data + "\n"; outputHandler(s, evt);
            };
            process.ErrorDataReceived += handler;

            process.Start();
            process.BeginErrorReadLine();

            process.WaitForExit();
            process.ErrorDataReceived -= handler;
            process.CancelErrorRead();

            string pattern = @"t:(?'time'\d+(?:\.\d+)*) type:\w last_keyframe:(?'group'\d+)";

            Regex regex = new Regex(pattern, RegexOptions.Multiline);

            var matches = regex.Matches(output);
            var blackFrames = new List<TimeSpan>();

            var matchGroups = matches.GroupBy(m => m.Groups["group"].Value);



            foreach (var group in matchGroups)
            {
                foreach (var match in group)
                {
                    decimal time;

                    if (Decimal.TryParse(match.Groups["time"].Value, out time))
                    {
                        blackFrames.Add(TimeSpan.FromSeconds((double)time));
                    }
                }

                var frame = new BlackFrame();

                frame.Start = blackFrames.First();
                frame.End = blackFrames.Last();
                frame.Duration = blackFrames.Last().Subtract(blackFrames.First());
                frame.Marker = frame.GetMiddle();

                frames.Add(frame);

                blackFrames = new List<TimeSpan>();
            }

            return frames;
        }
    }
}
