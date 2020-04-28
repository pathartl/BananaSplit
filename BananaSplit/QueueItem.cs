using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaSplit
{
    public class QueueItem
    {
        public string FileName { get; set; }
        public bool Scanned { get; set; }
        public DateTime LastScanned { get; set; }

        public QueueItem(string fileName)
        {
            FileName = fileName;
            Scanned = false;
        }
    }
}
