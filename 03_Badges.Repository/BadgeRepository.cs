using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges.Repository
{
    public class BadgeRepository
    {
        private readonly IDictionary<int, Badge> _badges = new Dictionary<int, Badge>();

        public int Count => _badges.Count;

        public bool Add(Badge badge)
        {
            int key = badge.ID;
            if (_badges.ContainsKey(key))
            {
                return false;
            }
            else
            {
                _badges[key] = badge;
                return true;
            }
        }

        public bool Contains(int key)
        {
            return _badges.ContainsKey(key);
        }

        public Badge Get(int key)
        {
            return _badges[key];
        }

        public IList<Badge> GetAll()
        {
            return _badges.Values.ToList();
        }
    }
}