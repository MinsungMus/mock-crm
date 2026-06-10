using System;
using System.Collections.Generic;
using System.Linq;

namespace DonorDashboard
{
    // This is our Donor class - think of it as a template/blueprint for donor data
    class Donor
    {
        // Properties store information about each donor
        public string Name { get; set; }
        public decimal TotalDonated { get; set; }
        public DateTime LastDonationDate { get; set; }

        // Constructor - runs when you create a new Donor
        public Donor(string name, decimal totalDonated, DateTime lastDonationDate)
        {
            Name = name;
            TotalDonated = totalDonated;
            LastDonationDate = lastDonationDate;
        }
    }

    class Program
    {
        // This List will hold all our donors - like a dynamic array
        static List<Donor> donors = new List<Donor>();

        static void Main(string[] args)
        {
            // Add some sample data so we have something to work with
            LoadSampleData();

            bool running = true;

            // Main program loop - keeps running until user chooses to exit
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== DONOR DASHBOARD ===");
                Console.WriteLine("1. View All Donors");
                Console.WriteLine("2. Add New Donor");
                Console.WriteLine("3. Search Donor by Name");
                Console.WriteLine("4. View Top Donors");
                Console.WriteLine("5. View Total Donations");
                Console.WriteLine("6. Exit");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine();

                // Switch statement checks which option the user picked
                switch (choice)
                {
                    case "1":
                        ViewAllDonors();
                        break;
                    case "2":
                        AddNewDonor();
                        break;
                    case "3":
                        SearchDonor();
                        break;
                    case "4":
                        ViewTopDonors();
                        break;
                    case "5":
                        ViewTotalDonations();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Thank you for using Donor Dashboard!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void LoadSampleData()
        {
            // Creating some sample donors to start with
            donors.Add(new Donor("John Smith", 5000.00m, new DateTime(2024, 11, 15)));
            donors.Add(new Donor("Sarah Johnson", 12500.50m, new DateTime(2024, 12, 1)));
            donors.Add(new Donor("Michael Brown", 3200.00m, new DateTime(2024, 10, 20)));
            donors.Add(new Donor("Emily Davis", 8750.25m, new DateTime(2024, 11, 28)));
        }

        static void ViewAllDonors()
        {
            Console.Clear();
            Console.WriteLine("=== ALL DONORS ===\n");

            if (donors.Count == 0)
            {
                Console.WriteLine("No donors found.");
            }
            else
            {
                // Loop through each donor and display their info
                foreach (var donor in donors)
                {
                    Console.WriteLine($"Name: {donor.Name}");
                    Console.WriteLine($"Total Donated: ${donor.TotalDonated:N2}");
                    Console.WriteLine($"Last Donation: {donor.LastDonationDate.ToShortDateString()}");
                    Console.WriteLine("---");
                }
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        static void AddNewDonor()
        {
            Console.Clear();
            Console.WriteLine("=== ADD NEW DONOR ===\n");

            // Get donor information from user
            Console.Write("Enter donor name: ");
            string name = Console.ReadLine();

            Console.Write("Enter total donated amount: $");
            decimal amount;
            // TryParse safely converts string to decimal - returns false if it fails
            while (!decimal.TryParse(Console.ReadLine(), out amount) || amount < 0)
            {
                Console.Write("Invalid amount. Please enter a valid number: $");
            }

            Console.Write("Enter last donation date (MM/DD/YYYY): ");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.Write("Invalid date. Please enter in format MM/DD/YYYY: ");
            }

            // Create and add the new donor to our list
            donors.Add(new Donor(name, amount, date));

            Console.WriteLine($"\n✓ {name} added successfully!");
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void SearchDonor()
        {
            Console.Clear();
            Console.WriteLine("=== SEARCH DONOR ===\n");

            Console.Write("Enter donor name to search: ");
            string searchName = Console.ReadLine();

            // LINQ query - finds donor whose name contains the search term (case-insensitive)
            var foundDonor = donors.FirstOrDefault(d =>
                d.Name.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0);

            if (foundDonor != null)
            {
                Console.WriteLine("\n✓ Donor Found:");
                Console.WriteLine($"Name: {foundDonor.Name}");
                Console.WriteLine($"Total Donated: ${foundDonor.TotalDonated:N2}");
                Console.WriteLine($"Last Donation: {foundDonor.LastDonationDate.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine($"\n✗ No donor found matching '{searchName}'");
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        static void ViewTopDonors()
        {
            Console.Clear();
            Console.WriteLine("=== TOP DONORS ===\n");

            // LINQ: OrderByDescending sorts by donation amount (highest first), Take gets top 5
            var topDonors = donors.OrderByDescending(d => d.TotalDonated).Take(5);

            int rank = 1;
            foreach (var donor in topDonors)
            {
                Console.WriteLine($"{rank}. {donor.Name} - ${donor.TotalDonated:N2}");
                rank++;
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        static void ViewTotalDonations()
        {
            Console.Clear();
            Console.WriteLine("=== DONATION SUMMARY ===\n");

            // LINQ: Sum adds up all TotalDonated values
            decimal total = donors.Sum(d => d.TotalDonated);
            int donorCount = donors.Count;

            Console.WriteLine($"Total Donors: {donorCount}");
            Console.WriteLine($"Total Donations: ${total:N2}");

            if (donorCount > 0)
            {
                decimal average = total / donorCount;
                Console.WriteLine($"Average Donation: ${average:N2}");
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}