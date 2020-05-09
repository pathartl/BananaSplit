using System;
using System.Collections.Generic;
using System.Text;

namespace BananaSplit
{
    public class Segment
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public TimeSpan Duration {
            get {
                return End.Subtract(Start);
            }
        }

        public override string ToString()
        {
            return Start.ToString() + "-" + End.ToString();
        }
    }
}
