﻿using _02_Claims.Repository;
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
                PrintClaim(claim);
            }
        }

        private void PrintClaim(Claim claim)
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