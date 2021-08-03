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
                TypeOfClaim = ClaimType.Car,
                Description = "Car accident on 465",
                ClaimAmount = 400.00m,
                DateOfIncident = DateTime.Parse("4/25/18"),
                DateOfClaim = DateTime.Parse("4/27/18")
            });

            _repository.Add(new Claim()
            {
                ClaimID = 2,
                TypeOfClaim = ClaimType.Home,
                Description = "House fire in kitchen",
                ClaimAmount = 4000.00m,
                DateOfIncident = DateTime.Parse("4/11/18"),
                DateOfClaim = DateTime.Parse("4/12/18")
            });

            _repository.Add(new Claim()
            {
                ClaimID = 3,
                TypeOfClaim = ClaimType.Theft,
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
            foreach (var claim in _repository.GetAll())
            {
                PrintClaimHorizontal(claim);
            }
            Console.WriteLine();
        }

        private void PrintClaimHorizontal(Claim claim)
        {
            Console.WriteLine($"ID: {claim.ClaimID}, Type: {claim.TypeOfClaim}, Description: {claim.Description}, Amount: ${claim.ClaimAmount}, DateOfIncident: {claim.DateOfIncident.ToShortDateString()}, DateOfClaim: {claim.DateOfClaim.ToShortDateString()}, IsValid: {claim.IsValid}");
        }

        private void PrintClaimVertical(Claim claim)
        {
            Console.WriteLine($"ClaimID: {claim.ClaimID}");
            Console.WriteLine($"Type: {claim.TypeOfClaim}");
            Console.WriteLine($"Description: {claim.Description}");
            Console.WriteLine($"Amount: ${claim.ClaimAmount}");
            Console.WriteLine($"DateOfIncident: {claim.DateOfIncident.ToShortDateString()}");
            Console.WriteLine($"DateOfClaim: {claim.DateOfClaim.ToShortDateString()}");
            Console.WriteLine($"IsValid: {claim.IsValid}");
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            if (_repository.Count <= 0)
            {
                Console.WriteLine("No claims!");
                return;
            }
            Console.WriteLine("Here are the details for the next claim to be handled:");
            Console.WriteLine();
            Claim next = _repository.SeeNextClaim();
            PrintClaimVertical(next);
            Console.WriteLine();
            bool answer = AskToHandleNextClaim();
            HandleClaimIfTrue(answer);
            Console.WriteLine();
        }

        private bool AskToHandleNextClaim()
        {
            Console.Write("Do you want to deal with this claim now (y/n)? ");
            string input = Console.ReadLine().ToLower();
            return input == "y";
        }

        private void HandleClaimIfTrue(bool answer)
        {
            Console.WriteLine();
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
            Console.Clear();
            Console.WriteLine("Enter new claim information");
            Console.WriteLine();
            var claim = AskForNewClaim();
            Console.WriteLine($"IsValid: {claim.IsValid}");
            Console.WriteLine();
            _repository.Add(claim);
        }

        private Claim AskForNewClaim()
        {
            var claim = new Claim();
            claim.ClaimID = AskForClaimID();
            claim.TypeOfClaim = AskForClaimType();
            claim.Description = AskForClaimDescription();
            claim.ClaimAmount = AskForClaimAmount();
            claim.DateOfIncident = AskForDateOfIncident();
            claim.DateOfClaim = AskForDateOfClaim();
            return claim;
        }

        private int AskForClaimID()
        {
            Console.Write("Enter the claim id: ");
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        private ClaimType AskForClaimType()
        {
            Console.Write("Enter the claim type: ");
            string input = Console.ReadLine().ToLower();
            
            switch (input)
            {
                case "car":
                    return ClaimType.Car;
                case "home":
                    return ClaimType.Home;
                case "theft":
                    return ClaimType.Theft;
                default:
                    return ClaimType.Car;
            }
        }

        private string AskForClaimDescription()
        {
            Console.Write("Enter a claim description: ");
            string input = Console.ReadLine();
            return input;
        }

        private decimal AskForClaimAmount()
        {
            Console.Write("Enter the claim amount: $");
            string input = Console.ReadLine();
            return decimal.Parse(input);
        }

        private DateTime AskForDateOfIncident()
        {
            Console.Write("Enter the date of incident: ");
            string input = Console.ReadLine();
            return DateTime.Parse(input);
        }

        private DateTime AskForDateOfClaim()
        {
            Console.Write("Enter the date of claim: ");
            string input = Console.ReadLine();
            return DateTime.Parse(input);
        }
    }
}