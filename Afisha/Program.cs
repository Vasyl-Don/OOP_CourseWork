using System;
using System.Collections.Generic;
using Theatre;

namespace Afisha
{
    class Afisha
    {
        static void Main()
        {
            Console.WriteLine("Hello");
            List<Performance> performances = new List<Performance>();
            FillList(performances);
            User user = new User();
            while(true)
            {
                Console.WriteLine("\n1 - Show full list of performances" +
                "\n2 - Searching system" +
                "\n3 - Buy tickets" +
                "\n4 - Book tickets" +
                "\n5 - Buy reserved tickets" +
                "\n6 - Show my tickets" +
                "\n7 - Show my reserved tickets" +
                "\n0 - Exit program");
                Console.Write("Choose an action: ");
                string choice = Console.ReadLine();
                if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "6" || choice == "7" || choice == "0")
                {
                    switch (choice)
                    {
                        case "1":
                            ShowFullList(performances);
                            break;
                        case "2":
                            Search(performances);
                            break;
                        case "3":
                            BuyingTickets(user, performances);
                            break;
                        case "4":
                            Console.WriteLine("Booking tickets");
                            break;
                        case "5":
                            Console.WriteLine("Buying reserved tickets");
                            break;
                        case "6":
                            Console.WriteLine("Your tickets:");
                            ShowUserTickets(user.ownTickets);
                            break;
                        case "7":
                            Console.WriteLine("Your reserved tickets:");
                            ShowUserTickets(user.reservedTickets);
                            break;
                        case "0":
                            Environment.Exit(0);
                            break;
                    }
                }
                else Console.WriteLine("Invalid input data. Try again");
            }
        }
        static void ShowInfo(Performance performance)
        {
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine("Name: " + performance.Name);
            Console.WriteLine("Author: " + performance.Author);
            Console.WriteLine("Genre: " + performance.Genre);
            Console.WriteLine("Date: " + performance.Date.ToString("d"));
            Console.WriteLine("ID: " + performance.ID);
            Console.WriteLine("Available tickets: ");
            foreach (Tickets t in performance.tickets)
                Console.WriteLine(t.TicketsType + ": " + t.AvailableTickets + "\t\tPrice: " + t.Price);
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = =");
        }
        static void ShowFullList(List<Performance> performances)
        {
            foreach (Performance p in performances)
                ShowInfo(p);
        }
        static void ShowUserTickets(List<UserTickets> tickets)
        {
            Console.WriteLine($"You have tickets for {tickets.Count} performances");
            foreach (UserTickets t in tickets)
            {
                Console.WriteLine("Performance ID: " + t.ID);
                Console.WriteLine("Type of seats: " + t.TicketsType);
                Console.WriteLine($"You have got {t.NumberOfTickets} tickets");
            }
        }
        static void Search(List<Performance> performances)
        {
            Console.WriteLine("\nWhat do you want to search by?");
            Console.WriteLine("1 - Author\n2 - Name\n3 - Genre\n4 - Date\n0 - Go back");
            Console.Write("Choose an action: ");
            string choice = Console.ReadLine();
            bool foundPerformances = false;
            if (choice == "1" || choice == "2" || choice == "3")
            {
                Console.Write("Input your parameter: ");
                string parameter = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        foreach (Performance p in performances)
                            if (p.Author == parameter)
                            {
                                ShowInfo(p);
                                foundPerformances = true;
                            }
                        break;
                    case "2":
                        foreach (Performance p in performances)
                            if (p.Name == parameter)
                            {
                                ShowInfo(p);
                                foundPerformances = true;
                            }
                        break;
                    case "3":
                        Enum.TryParse(parameter, out Performance.Genres genre);
                        foreach (Performance p in performances)
                            if (p.Genre == genre)
                            {
                                ShowInfo(p);
                                foundPerformances = true;
                            }
                        break;
                }
                if (!foundPerformances)
                    Console.WriteLine("No Performances found. Try something else");
            }
            else if (choice == "4")
            {
                Console.WriteLine("Show performances for:" +
                    "\n1 - Next week" +
                    "\n2 - Next 2 weeks" +
                    "\n3 - Next 3 weeks" +
                    "\n4 - Particular date" +
                    "\n0 - Go back");
                Console.Write("Choose an action: ");
                string dateChoice = Console.ReadLine();
                if (dateChoice == "1" || dateChoice == "2" || dateChoice == "3")
                {
                    foreach (Performance p in performances)
                    {
                        if (p.Date - DateTime.Now <= new TimeSpan(7 * int.Parse(dateChoice), 0, 0, 0))
                        {
                            ShowInfo(p);
                            foundPerformances = true;
                        }
                    }
                }
                else if (dateChoice == "4")
                {
                    Console.Write("Input date: ");
                    DateTime.TryParse(Console.ReadLine(), out DateTime date);
                    foreach (Performance p in performances)
                    {
                        if (p.Date == date)
                        {
                            ShowInfo(p);
                            foundPerformances = true;
                        }
                    }
                    if (!foundPerformances)
                        Console.WriteLine("No Performances found. Try something else");
                }
                else if (dateChoice == "0")
                    Search(performances);
                else
                {
                    Console.WriteLine("Invalid input data. Try Again");
                    Search(performances);
                }
            }
            else if (choice == "0") { }
            else
            {
                Console.WriteLine("Invalid input data. Try Again");
                Search(performances);
            }
        }
        static void BuyingTickets(User user, List<Performance> performances)
        {
            Console.Write("Input an ID of performance: ");
            uint.TryParse(Console.ReadLine(), out uint ID);
            bool performanceFound = false;
            foreach(Performance p in performances)
            {
                if(p.ID == ID)
                {
                    ShowInfo(performances[Convert.ToInt32(ID) - 1]);
                    Console.Write("Choose a type of seats (Parter/Amphiteater/Balcony): ");
                    Enum.TryParse(Console.ReadLine(), out Tickets.TicketsTypes ticketsType);
                    uint numberOfTickets = uint.Parse(Console.ReadLine());
                    performanceFound = true;
                    user.AddTickets(user.ownTickets, ID, ticketsType, numberOfTickets);
                }
            }
            if(!performanceFound)
            {
                Console.WriteLine("No performance found. Try something else");
            }
        }
        static void FillList(List<Performance> performances)
        {
            performances.Add(new Performance("William Shakespeare", "Romeo and Juliett", Performance.Genres.Tragedy, new DateTime(2021, 6, 18), 400, 300, 500));
            performances.Add(new Performance("William Shakespeare", "Gamlet", Performance.Genres.Tragedy, new DateTime(2021, 6, 19), 450, 350, 550));
            performances.Add(new Performance("Ivan Franko", "Stolen Happiness", Performance.Genres.Drama, new DateTime(2021, 6, 25), 350, 250, 400));
            performances.Add(new Performance("Mykola Kulish", "Myna Mazailo", Performance.Genres.Comedy, new DateTime(2021, 6, 26), 350, 250, 400));
            performances.Add(new Performance("Ivan Kotlyarevsky", "Natalka Poltavka", Performance.Genres.Drama, new DateTime(2021, 7, 2), 400, 225, 450));
            performances.Add(new Performance("William Shakespeare", "Midsummer Night's Dream", Performance.Genres.Comedy, new DateTime(2021, 7, 3), 320, 250, 350));
            performances.Add(new Performance("Erich Remarque", "Three Comrades", Performance.Genres.Drama, new DateTime(2021, 7, 3), 325, 300, 380));
            performances.Add(new Performance("Bernard Shaw", "Pygmalion", Performance.Genres.Comedy, new DateTime(2021, 7, 4), 350, 325, 400));
            performances.Add(new Performance("William Shakespeare", "King Lear", Performance.Genres.Tragedy, new DateTime(2021, 7, 11), 400, 325, 450));
        }
    }
}
