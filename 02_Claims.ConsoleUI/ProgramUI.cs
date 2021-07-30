using System;

namespace _02_Claims.ConsoleUI
{
    public class ProgramUI
    {
        public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item:");
                Console.WriteLine("1. See all claims");
                Console.WriteLine("2. Take care of next claim");
                Console.WriteLine("3. Enter a new claim");
                Console.WriteLine("4. Exit application");
                Console.WriteLine();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
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

        private void SeeAllClaims()
        {
            throw new NotImplementedException();
        }

        private void TakeCareOfNextClaim()
        {
            throw new NotImplementedException();
        }

        private void EnterNewClaim()
        {
            throw new NotImplementedException();
        }
    }
}