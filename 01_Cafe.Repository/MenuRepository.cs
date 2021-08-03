using System.Collections.Generic;

namespace _01_Cafe.Repository
{
    public class MenuRepository
    {
        private readonly IList<Menu> _menuItems = new List<Menu>();

        public int Count => _menuItems.Count;

        public void Add(Menu menuItem)
        {
            _menuItems.Add(menuItem);
            menuItem.Number = _menuItems.Count;
        }

        public Menu Get(int menuNumber)
        {
            menuNumber--;  // Menu numbers start at 1, but are accessed internally starting at 0
            if (menuNumber >= 0 && menuNumber < _menuItems.Count)
            {
                return _menuItems[menuNumber];
            }
            else
            {
                return null;
            }
        }

        public IList<Menu> GetAll()
        {
            return _menuItems;
        }

        public bool Delete(int menuNumber)
        {
            int index = menuNumber - 1;
            if (index >= 0 && index < _menuItems.Count)
            {
                _menuItems.RemoveAt(index);
                UpdateMenuNumbersAfter(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateMenuNumbersAfter(int index)
        {
            for (int i = index; i < _menuItems.Count; i++)
            {
                _menuItems[i].Number = i + 1;
            }
        }
    }
}
