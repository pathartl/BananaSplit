using System;

namespace BananaSplit
{
    public class BlackFrame
    {
        public Guid Id { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public TimeSpan Duration { get; set; }

        public ReferenceFrame ReferenceFrame { get; set; }
        public bool Selected { get; set; }

        public BlackFrame()
        {
            Id = Guid.NewGuid();
        }
    }
}
