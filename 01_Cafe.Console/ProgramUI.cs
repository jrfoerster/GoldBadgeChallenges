using _01_Cafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe.ConsoleUI
{
    public class ProgramUI
    {
        private readonly MenuRepository _repository = new MenuRepository();
        public void Run()
        {
            AddDefaultMenuItems();
            MainMenu();
        }

        private void AddDefaultMenuItems()
        {
            _repository.Add(new Menu()
            {
                Name = "Double Bacon Burger Combo",
                Description = "Double Bacon Burger on our homemade bun, plus steak fries and a refreshing drink",
                Ingredients = "Bacon Burger, Large Fries, Large Drink",
                Price = 10.99m
            });

            _repository.Add(new Menu()
            {
                Name = "Triple Grilled Cheese Combo",
                Description = "Grilled cheese with our triple cheese blend, plus steak fries and a refreshing drink",
                Ingredients = "Grilled Cheese, Large Fries, Large Drink",
                Price = 8.99m
            });

            _repository.Add(new Menu()
            {
                Name = "Spicy Chicken Sandwich Combo",
                Description = "Better than the best, a fried chicken sandwich with our signature spicy sauce, plus steak fries and a refreshing drink",
                Ingredients = "Spicy Chicken Sandwich, Large Fries, Large Drink",
                Price = 9.99m
            });
        }

        private void MainMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. View all menu items");
                Console.WriteLine("2. Add a new menu item");
                Console.WriteLine("3. Delete a menu item");
                Console.WriteLine("4. Exit application");
                Console.WriteLine();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllMenuItems();
                        break;
                    case "2":
                        AddNewMenuItem();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        isRunning = false;
                        continue;
                    default:
                        Console.WriteLine("Choose an available option");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void ViewAllMenuItems()
        {
            Console.Clear();
            for (int i = 1; i <= _repository.Count; i++)
            {
                Menu item = _repository.Get(i);
                Console.WriteLine($"#{i} - {item.Name} - ${item.Price}");
                Console.WriteLine(item.Description);
                Console.WriteLine($"Includes: {item.Ingredients}");
                Console.WriteLine();
            }
        }

        private void AddNewMenuItem()
        {
            Console.Clear();
            Menu menuItem = GetMenuItemFromUser();
            _repository.Add(menuItem);
            Console.WriteLine($"Menu item {menuItem.Name} successfully created");
            Console.WriteLine();
        }

        private Menu GetMenuItemFromUser()
        {
            Menu menuItem = new Menu();

            Console.Write("Enter the name of the new menu item: ");
            menuItem.Name = Console.ReadLine();

            Console.Write("Enter the description of the menu item: ");
            menuItem.Description = Console.ReadLine();

            Console.Write("Enter the ingredients of the menu item: ");
            menuItem.Ingredients = Console.ReadLine();

            Console.Write("Enter the price of the menu item: ");
            menuItem.Price = GetPriceFromUser();

            return menuItem;
        }

        private decimal GetPriceFromUser()
        {
            string input = Console.ReadLine();
            
            if (decimal.TryParse(input, out decimal price))
            {
                return price;
            }
            else
            {
                return 0.00m;
            }
        }

        private void DeleteMenuItem()
        {
            ViewAllMenuItems();
            Console.Write("Enter the menu number to delete: ");
            int index = GetMenuNumberFromUser();
            Menu item = _repository.Get(index);
            bool wasDeleted = _repository.Delete(index);

            if (wasDeleted)
            {
                Console.WriteLine($"Menu item #{index} - {item.Name} sucessfully deleted");
            }
            else
            {
                Console.WriteLine($"Menu item does not exist");
            }

            Console.WriteLine();
        }

        private int GetMenuNumberFromUser()
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index))
            {
                return index;
            }
            else
            {
                return -1;  // This index is not valid
            }
        }
    }
}
