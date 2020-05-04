using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace BananaSplit
{
    public class FFMPEG
    {
        private Process Process { get; set; }

        public FFMPEG()
        {
            Process = new Process();

            Process.StartInfo.UseShellExecute = false;
            Process.StartInfo.RedirectStandardError = true;
            Process.StartInfo.FileName = "ffmpeg.exe";
            Process.StartInfo.CreateNoWindow = true;
        }

        public bool IsMatroska(string filePath)
        {
            Process.StartInfo.FileName = "ffprobe.exe";
            Process.StartInfo.Arguments = $"\"{filePath}\"";

            Process.Start();

            var output = Process.StandardError.ReadToEnd();

            string pattern = @"^Input #\d+, matroska";

            Regex regex = new Regex(pattern, RegexOptions.Multiline);

            return regex.IsMatch(output);
        }

        public TimeSpan GetDuration(string filePath)
        {
            TimeSpan duration = new TimeSpan();

            Process.StartInfo.FileName = "ffprobe.exe";
            Process.StartInfo.Arguments = $"\"{filePath}\"";

            Process.Start();

            var output = Process.StandardError.ReadToEnd();

            string pattern = @"^\s+Duration: (?<duration>\d+(?:.\d+)*)";

            Regex regex = new Regex(pattern, RegexOptions.Multiline);

            if (regex.IsMatch(output))
            {
                var durationString = regex.Match(output).Groups["duration"].Value;
                TimeSpan.TryParse(durationString, out duration);
            }

            return duration;
        }

        public byte[] ExtractFrame(string filePath, TimeSpan time)
        {
            var timespan = String.Format("{0:D2}:{1:D2}:{2:D2}.{3}", time.Hours, time.Minutes, time.Seconds, time.Milliseconds);

            Process.StartInfo.FileName = "ffmpeg.exe";
            Process.StartInfo.Arguments = $"-ss {timespan} -i \"{filePath}\" -vframes 1 -c:v png -f image2pipe -";
            Process.StartInfo.RedirectStandardOutput = true;
            Process.StartInfo.RedirectStandardError = false;

            Process.Start();

            using (MemoryStream ms = new MemoryStream())
            {
                Process.StandardOutput.BaseStream.CopyTo(ms);

                Process.WaitForExit();
                return ms.ToArray();
            }
        }

        public void EncodeSegments(string source, string destination, string arguments, Segment segment)
        {
            arguments = arguments.Replace("{source}", source);
            arguments = arguments.Replace("{destination}", destination);
            arguments = arguments.Replace("{start}", String.Format("{0:D2}:{1:D2}:{2:D2}.{3}", segment.Start.Hours, segment.Start.Minutes, segment.Start.Seconds, segment.Start.Milliseconds));
            arguments = arguments.Replace("{end}", String.Format("{0:D2}:{1:D2}:{2:D2}.{3}", segment.End.Hours, segment.End.Minutes, segment.End.Seconds, segment.End.Milliseconds));
            arguments = arguments.Replace("{duration}", String.Format("{0:D2}:{1:D2}:{2:D2}.{3}", segment.Duration.Hours, segment.Duration.Minutes, segment.Duration.Seconds, segment.Duration.Milliseconds));

            Process.StartInfo.FileName = "ffmpeg.exe";
            Process.StartInfo.Arguments = arguments;
            Process.StartInfo.RedirectStandardOutput = false;
            Process.StartInfo.RedirectStandardError = true;

            Process.Start();

            var error = Process.StandardError.ReadToEnd();

            Process.WaitForExit();
        }

        public ICollection<BlackFrame> DetectBlackFrames(string filePath, double blackFrameDuration, double blackFrameThreshold)
        {
            var frames = new List<BlackFrame>();

            Process.StartInfo.RedirectStandardError = true;
            Process.StartInfo.Arguments = $"-i \"{filePath}\" -vf blackdetect=d={blackFrameDuration}:pix_th={blackFrameThreshold} -f rawvideo -y /NUL";

            Process.Start();

            // ffmpeg uses stderr for some reason
            var output = Process.StandardError.ReadToEnd();

            Process.WaitForExit();

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

                    frames.Add(frame);
                }
                catch { }
            }

            return frames;
        }
    }
}
