using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges.Repository
{
    public class Badge
    {
        public int ID { get; set; }
        public IList<string> Doors { get; } = new List<string>();
        public string Name { get; set; }
    }
}
