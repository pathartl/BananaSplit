using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaSplit
{
    public class ReferenceFrame
    {
        public DateTime ExtractedOn { get; set; }
        public byte[] Data { get; set; }
        TimeSpan Position { get; set; }
    }
}
