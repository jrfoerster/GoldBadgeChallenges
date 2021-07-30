using _02_Claims.Repository;
using System;

namespace _02_Claims.ConsoleUI
{
    public class ProgramUI
    {
        private readonly ClaimsRepository _repository = new ClaimsRepository();

        public void Run()
        {
            AddDefaultClaims();
            MainMenu();
        }

        private void AddDefaultClaims()
        {
            _repository.Add(new Claim()
            {
                ClaimID = 1,
                Type = ClaimType.Car,
                Description = "Car accident on 465",
                ClaimAmount = 400.00m,
                DateOfIncident = DateTime.Parse("4/25/18"),
                DateOfClaim = DateTime.Parse("4/27/18")
            });

            _repository.Add(new Claim()
            {
                ClaimID = 2,
                Type = ClaimType.Home,
                Description = "House fire in kitchen",
                ClaimAmount = 4000.00m,
                DateOfIncident = DateTime.Parse("4/11/18"),
                DateOfClaim = DateTime.Parse("4/12/18")
            });

            _repository.Add(new Claim()
            {
                ClaimID = 3,
                Type = ClaimType.Theft,
                Description = "Stolen pancakes",
                ClaimAmount = 4.00m,
                DateOfIncident = DateTime.Parse("4/27/18"),
                DateOfClaim = DateTime.Parse("6/01/18")
            });
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
            Console.Clear();
            foreach (Claim claim in _repository.GetAll())
            {
                PrintClaimHorizontal(claim);
            }
            Console.WriteLine();
        }

        private void PrintClaimHorizontal(Claim claim)
        {
            Console.WriteLine($"ID: {claim.ClaimID}, Type: {claim.Type}, Description: {claim.Description}, Amount: ${claim.ClaimAmount}, DateOfIncident: {claim.DateOfIncident.ToShortDateString()}, DateOfClaim: {claim.DateOfClaim.ToShortDateString()}, IsValid: {claim.IsValid}");
        }

        private void PrintClaimVertical(Claim claim)
        {
            Console.WriteLine($"ClaimID: {claim.ClaimID}");
            Console.WriteLine($"Type: {claim.Type}");
            Console.WriteLine($"Description: {claim.Description}");
            Console.WriteLine($"Amount: ${claim.ClaimAmount}");
            Console.WriteLine($"DateOfIncident: {claim.DateOfIncident.ToShortDateString()}");
            Console.WriteLine($"DateOfClaim: {claim.DateOfClaim.ToShortDateString()}");
            Console.WriteLine($"IsValid: {claim.IsValid}");
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details for the next claim to be handled:");
            Console.WriteLine();
            Claim next = _repository.SeeNextClaim();
            PrintClaimVertical(next);
            Console.WriteLine();
            AskToHandleNextClaim();
            Console.WriteLine();
        }

        private void AskToHandleNextClaim()
        {
            Console.Write("Do you want to deal with this claim now (y/n)? ");
            string input = Console.ReadLine().ToLower();
            bool answer = input == "y";
            HandleClaimIfTrue(answer);
        }

        private void HandleClaimIfTrue(bool answer)
        {
            if (answer)
            {
                Console.WriteLine("Claim processed!");
                _repository.HandleNextClaim();
            }
            else
            {
                Console.WriteLine("Claim not processed, returning to Main Menu");
            }
        }

        private void EnterNewClaim()
        {
            throw new NotImplementedException();
        }
    }
}