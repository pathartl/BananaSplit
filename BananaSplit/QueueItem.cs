using System;
using System.Collections.Generic;
using System.Linq;

namespace BananaSplit
{
    public class QueueItem
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public bool Scanned { get; set; }
        public DateTime LastScanned { get; set; }
        public ICollection<BlackFrame> BlackFrames { get; set; }
        public TimeSpan Duration { get; set; }

        public QueueItem(string fileName)
        {
            Id = Guid.NewGuid();
            FileName = fileName;
            Scanned = false;
            BlackFrames = new List<BlackFrame>();
        }

        public ICollection<Segment> GetSegments()
        {
            var segments = new List<Segment>();
            var selectedFrames = BlackFrames.Where(bf => bf.Selected).ToList();

            if (selectedFrames.Count > 0)
            {
                // The first segment starts at the beginning of the video and ends at the start of the first black frame
                var start = new Segment()
                {
                    Start = new TimeSpan(0, 0, 0),
                    End = selectedFrames.First().GetMiddle()
                };

                // The last segment starts at the end of the last black frame to the end of the video
                var end = new Segment()
                {
                    Start = selectedFrames.Last().GetMiddle(),
                    End = Duration
                };

                var additionalSegments = new List<Segment>();

                int index = 0;

                // Loop through to get any additional segments.
                while (additionalSegments.Count < selectedFrames.Count - 1)
                {
                    additionalSegments.Add(new Segment()
                    {
                        Start = selectedFrames[index].GetMiddle(),
                        End = selectedFrames[index + 1].GetMiddle()
                    });

                    index++;
                }

                segments.Add(start);
                segments.AddRange(additionalSegments);
                segments.Add(end);
            }

            return segments;
        }
    }
}
