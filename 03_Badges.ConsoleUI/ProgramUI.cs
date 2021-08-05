using _03_Badges.Repository;
using System;
using System.Collections.Generic;

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
            CreateAndAddBadge(12345, "A7");
            CreateAndAddBadge(22345, "A1", "A4", "B1", "B2");
            CreateAndAddBadge(32345, "A4", "A5");
        }

        private void CreateAndAddBadge(int id, params string[] doors)
        {
            var badge = new Badge(id, doors);
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
                        AddNewBadge();
                        break;
                    case "2":
                        EditExistingBadge();
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

        private void AddNewBadge()
        {
            Console.Clear();
            Console.WriteLine("Enter new badge information");
            Console.WriteLine();

            int id = AskForID();
            if (_repository.Contains(id))
            {
                Console.WriteLine();
                Console.WriteLine($"Badge {id} already exists!");
            }
            else
            {
                IList<string> doors = AskForDoors();
                var badge = new Badge(id, doors);
                _repository.Add(badge);
                Console.WriteLine();
                WriteBadgeSentence(badge);
            }
        }

        private int AskForID()
        {
            int id;
            bool isAsking = true;
            do
            {
                Console.Write("Enter badge number: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out id))
                {
                    isAsking = false;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            } while (isAsking);
            return id;
        }

        private IList<string> AskForDoors()
        {
            Console.Write("Enter doors separated by comma: ");
            string input = Console.ReadLine();
            string[] doors = input.Split(',');
            return TrimInputToList(doors);
        }

        private IList<string> TrimInputToList(string[] doors)
        {
            var output = new List<string>();
            foreach (string door in doors)
            {
                string d = door.Trim();
                if (d != string.Empty)
                {
                    output.Add(d);
                }
            }
            return output;
            //return doors.Select(x => x.Trim()).Where(x => x != string.Empty).ToList();
        }

        private void EditExistingBadge()
        {
            ListAllBadges();

            int id = AskForID();
            if (_repository.Contains(id))
            {
                var badge = _repository.Get(id);
                EditBadgeSubMenu(badge);
            }
            else
            {
                Console.WriteLine("Not a valid badge number!");
            }
            Console.WriteLine();
        }

        private void EditBadgeSubMenu(Badge badge)
        {
            Console.Clear();
            WriteBadgeSentence(badge);
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add doors");
            Console.WriteLine("2. Remove doors");
            Console.WriteLine("3. Remove all doors");
            Console.WriteLine();
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    AddDoorsTo(badge);
                    break;
                case "2":
                    RemoveDoorsFrom(badge);
                    break;
                case "3":
                    RemoveAllDoorsFrom(badge);
                    break;
                default:
                    Console.WriteLine("Not a valid option");
                    break;
            }
        }

        private void WriteBadgeSentence(Badge badge)
        {
            string doorString = DoorOrDoors(badge.Doors.Count).ToLower();
            Console.Write($"Badge {badge.ID} has access to {doorString} ");
            WriteDoors(badge.Doors);
            Console.WriteLine();
        }

        private void AddDoorsTo(Badge badge)
        {
            IList<string> doors = AskForDoors();
            foreach (string door in doors)
            {
                badge.Doors.Add(door);
            }
            Console.WriteLine();
            string doorString = DoorOrDoors(doors.Count);
            Console.WriteLine($"{doorString} added");
            WriteBadgeSentence(badge);
        }

        private void RemoveDoorsFrom(Badge badge)
        {
            IList<string> doors = AskForDoors();
            foreach (string door in doors)
            {
                badge.Doors.Remove(door);
            }
            Console.WriteLine();
            string doorString = DoorOrDoors(doors.Count);
            Console.WriteLine($"{doorString} removed");
            WriteBadgeSentence(badge);
        }

        private string DoorOrDoors(int length)
        {
            if (length == 0)
            {
                return "No doors";
            }
            else if (length == 1)
            {
                return "Door";
            }
            else
            {
                return "Doors";
            }
        }

        private void RemoveAllDoorsFrom(Badge badge)
        {
            badge.Doors.Clear();
            Console.WriteLine($"All doors removed from Badge {badge.ID}");
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
            WriteDoors(badge.Doors);
            Console.WriteLine();
        }

        private void WriteDoors(IList<string> doors)
        {
            for (int i = 0; i < doors.Count; i++)
            {
                Console.Write(doors[i]);
                if (i < doors.Count - 1)
                {
                    Console.Write(", ");
                }
            }
        }
    }
}