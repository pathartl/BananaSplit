using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaSplit
{
    public class QueueItem
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public bool Scanned { get; set; }
        public DateTime LastScanned { get; set; }
        public ICollection<BlackFrame> BlackFrames { get; set; }

        public QueueItem(string fileName)
        {
            Id = Guid.NewGuid();
            FileName = fileName;
            Scanned = false;
            BlackFrames = new List<BlackFrame>();
        }
    }
}
