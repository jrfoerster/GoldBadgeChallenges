using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe.Repository
{
    public class MenuRepository
    {
        private readonly List<Menu> _menuItems = new List<Menu>();

        public int Count
        {
            get
            {
                return _menuItems.Count;
            }
        }

        public void Add(Menu menuItem)
        {
            _menuItems.Add(menuItem);
        }

        public Menu Get(int menuNumber)
        {
            //foreach (var menu in _menuItems)
            //{
            //    if (menu.Number == menuNumber)
            //    {
            //        return menu;
            //    }
            //}
            //return null;
            menuNumber--;
            if (menuNumber >= 0 && menuNumber < _menuItems.Count)
            {
                return _menuItems[menuNumber];
            }
            else
            {
                return null;
            }
        }

        public List<Menu> GetAll()
        {
            return _menuItems.ToList();
        }

        public bool Delete(int menuNumber)
        {
            //int index = -1;
            //for (int i = 0; i < _menuItems.Count; i++)
            //{
            //    if (_menuItems[i].Number == menuNumber)
            //    {
            //        index = i;
            //        break;
            //    }
            //}

            //if (index == -1)
            //{
            //    return false;
            //}
            //else
            //{
            //    _menuItems.RemoveAt(index);
            //    return true;
            //}
            menuNumber--;
            if (menuNumber >= 0 && menuNumber < _menuItems.Count)
            {
                _menuItems.RemoveAt(menuNumber);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Menu menu)
        {
            return _menuItems.Remove(menu);
        }
    }
}
