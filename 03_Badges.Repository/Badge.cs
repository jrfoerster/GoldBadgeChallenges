using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges.Repository
{
    public class Badge
    {
        public int ID { get; }
        public IList<string> Doors { get; }
        public string Name { get; set; } = string.Empty;

        public Badge(int id)
        {
            ID = id;
            Doors = new List<string>();
        }

        public Badge(int id, IEnumerable<string> doors)
        {
            ID = id;
            Doors = new List<string>(doors);
        }
    }
}
