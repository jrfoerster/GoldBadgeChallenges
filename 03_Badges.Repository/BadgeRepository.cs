using System.Collections.Generic;

namespace _03_Badges.Repository
{
    public class BadgeRepository
    {
        private readonly IDictionary<int, Badge> _badges = new Dictionary<int, Badge>();

        public int Count => _badges.Count;

        public bool AddSafe(Badge badge)
        {
            int key = badge.ID;
            if (_badges.ContainsKey(key))
            {
                return false;
            }
            else
            {
                _badges.Add(key, badge);
                return true;
            }
        }

        public void Add(Badge badge)
        {
            _badges.Add(badge.ID, badge);
        }

        public bool Contains(int key)
        {
            return _badges.ContainsKey(key);
        }

        public Badge Get(int key)
        {
            return _badges[key];
        }

        public IEnumerable<Badge> GetAll()
        {
            return _badges.Values;
        }
    }
}