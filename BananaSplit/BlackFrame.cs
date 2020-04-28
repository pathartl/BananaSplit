using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaSplit
{
    public class BlackFrame
    {
        public Guid Id { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public TimeSpan Duration { get; set; }

        public ReferenceFrame ReferenceFrame { get; set; }

        public BlackFrame()
        {
            Id = Guid.NewGuid();
        }
    }
}
