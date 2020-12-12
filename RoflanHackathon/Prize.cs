using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoflanHackathon
{
    class Prize
    {
        public int SetsCount { get; set; }
        public string Points { get; set; }
        public Prize(int setsCount, string points)
        {
            SetsCount = setsCount;
            Points = points;
        }
    }
}
