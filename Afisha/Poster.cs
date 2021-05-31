using System;
using System.Collections.Generic;
using Theatre;

namespace Poster
{
    class Poster
    {
        static void Main()
        {
            Console.WriteLine("Hello! It is theater poster program. You can buy/reserve tickets for performances with it");
            List<Performance> performances = new List<Performance>();
            FillList(performances);
            User user = new User();
            while(true)
            {
                Console.WriteLine("\n1 - Show full list of performances" +
                "\n2 - Searching system" +
                "\n3 - Buy tickets" +
                "\n4 - Reserve tickets" +
                "\n5 - Buy reserved tickets" +
                "\n6 - Show my tickets" +
                "\n7 - Show my reserved tickets" +
                "\n8 - Return my tickets" +
                "\n9 - Return my reserrved tickets" +
                "\n0 - Exit program");
                Console.Write("Choose an action: ");
                string choice = Console.ReadLine();
                if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "6" || choice == "7" || choice == "8" || choice == "9" || choice == "0")
                {
                    switch (choice)
                    {
                        case "1":
                            Output.ShowFullList(performances);
                            break;
                        case "2":
                            Search(performances);
                            break;
                        case "3":
                           CashRegister.BuyingTickets(user, performances);
                            break;
                        case "4":
                            CashRegister.ReservisingTickets(user, performances);
                            break;
                        case "5":
                            CashRegister.BuyingReservedTickets(user, performances);
                            break;
                        case "6":
                            Console.WriteLine("\nYour tickets:");
                            Output.ShowUserTickets(user.ownTickets);
                            break;
                        case "7":
                            Console.WriteLine("\nYour reserved tickets:");
                            Output.ShowUserTickets(user.ownReservedTickets);
                            break;
                        case "0":
                            Environment.Exit(0);
                            break;
                    }
                }
                else Console.WriteLine("Invalid input data. Try again");
            }
        }
        
        static void Search(List<Performance> performances)
        {
            Console.WriteLine("\nWhat do you want to search by?");
            Console.WriteLine("1 - Author\n2 - Name\n3 - Genre\n4 - Date\n5 - ID\n0 - Go back");
            Console.Write("Choose an action: ");
            string choice = Console.ReadLine();
            bool foundPerformances = false;
            if (choice == "1" || choice == "2" || choice == "3" || choice == "5")
            {
                Console.Write("Input your parameter: ");
                string parameter = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        foreach (Performance p in performances)
                            if (p.Author == parameter)
                            {
                                Output.ShowInfo(p);
                                foundPerformances = true;
                            }
                        break;
                    case "2":
                        foreach (Performance p in performances)
                            if (p.Name == parameter)
                            {
                                Output.ShowInfo(p);
                                foundPerformances = true;
                            }
                        break;
                    case "3":
                        Enum.TryParse(parameter, out Performance.Genres genre);
                        foreach (Performance p in performances)
                            if (p.Genre == genre)
                            {
                                Output.ShowInfo(p);
                                foundPerformances = true;
                            }
                        break;
                    case "5":
                        if (int.Parse(parameter) > 0 && int.Parse(parameter) <= performances.Count)
                        {
                            foundPerformances = true;
                            Output.ShowInfo(performances[int.Parse(parameter) - 1]);
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
                            Output.ShowInfo(p);
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
                            Output.ShowInfo(p);
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
