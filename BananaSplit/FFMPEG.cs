using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        }

        public ICollection<BlackFrame> DetectBlackFrames(string filePath)
        {
            var frames = new List<BlackFrame>();

            Process.StartInfo.Arguments = $"-i \"{filePath}\" -vf blackdetect=d=0.04:pix_th=.01 -f rawvideo -y /NUL";

            Process.Start();

            // ffmpeg uses stderr for some reason
            var output = Process.StandardError.ReadToEnd();

            string pattern = @"(?:blackdetect.+)(?:black_start:)(?<start>\d+(?:.\d+)) (?:black_end:)(?<end>\d+(?:.\d+)) (?:black_duration:)(?<duration>\d+(?:.\d+))";

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

                    frame.Start = start;
                    frame.End = end;
                    frame.Duration = duration;

                    frames.Add(frame);
                }
                catch { }
            }

            Process.WaitForExit();

            return frames;
        }
    }
}
