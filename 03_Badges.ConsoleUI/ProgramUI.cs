using _03_Badges.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges.ConsoleUI
{
    class ProgramUI
    {
        private readonly BadgeRepository _repository = new BadgeRepository();

        public void Run()
        {
            AddDefaultBadges();
            MainMenu();
        }

        private void AddDefaultBadges()
        {
            AddDefaultBadge(12345, "A7");
            AddDefaultBadge(22345, "A1", "A4", "B1", "B2");
            AddDefaultBadge(32345, "A4", "A5");
        }

        private void AddDefaultBadge(int id, params string[] doors)
        {
            var badge = new Badge(id);
            foreach (var door in doors)
            {
                badge.Doors.Add(door);
            }
            _repository.Add(badge);
        }

        private void MainMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item:");
                Console.WriteLine("1. Add a badge");
                Console.WriteLine("2. Edit a badge");
                Console.WriteLine("3. List all badges");
                Console.WriteLine("4. Exit application");
                Console.WriteLine();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":
                        ListAllBadges();
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

        private void ListAllBadges()
        {
            Console.Clear();
            Console.WriteLine("Badge - Door Access");

            foreach (var badge in _repository.GetAll())
            {
                WriteBadge(badge);
            }

            Console.WriteLine();
        }

        private void WriteBadge(Badge badge)
        {
            Console.Write($"{badge.ID} - ");

            var doors = badge.Doors;
            for (int i = 0; i < doors.Count; i++)
            {
                Console.Write(doors[i]);
                if (i < doors.Count - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }
    }
}