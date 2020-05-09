using System;

namespace BananaSplit
{
    public class BlackFrame
    {
        public Guid Id { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public TimeSpan Marker { get; set; }
        public TimeSpan Duration { get; set; }

        public ReferenceFrame ReferenceFrame { get; set; }
        public decimal ReferenceFrameOffset { get; set; }
        public bool Selected { get; set; }

        public BlackFrame()
        {
            Id = Guid.NewGuid();
        }

        public TimeSpan GetMiddle()
        {
            var halfDuration = new TimeSpan(Duration.Ticks / 2);

            return End.Subtract(halfDuration);
        }
    }
}
