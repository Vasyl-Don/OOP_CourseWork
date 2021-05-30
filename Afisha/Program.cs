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
            while(true)
            {
                MyMain(performances);
            }
        }
        static void MyMain(List<Performance> performances)
        {
            Console.WriteLine("\n1 - Show full list of performances" +
                "\n2 - Searching system" +
                "\n3 - Buy tickets to a particular Performance" +
                "\n4 - Show my tickets" +
                "\n0 - Exit program");
            Console.Write("Choose an action: ");
            string choice = Console.ReadLine();
            if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "0")
            {
                switch(choice)
                {
                    case "1":
                        ShowFullList(performances);
                        break;
                    case "2":
                        Search(performances);
                        break;
                    case "3":
                        // go back
                        Console.WriteLine("Here is bying tickets");
                        break;
                    case "4":
                        Console.WriteLine("Here I show you your tickets");
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                }
            }
            else Console.WriteLine("Invalid input data. Try again");
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
                Console.WriteLine(t.ticketsType + ": " + t.AvailableTickets + "\t\tPrice: " + t.Price);
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = =");
        }
        static void ShowFullList(List<Performance> performances)
        {
            foreach (Performance p in performances)
                ShowInfo(p);
        }
        static void ShowMyTickets(User user)
        {
            Console.WriteLine($"You have tickets for {user.tickets.Count} performances:");

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
            }
            else if (choice == "4")
            {
                Console.WriteLine("Show performances for:" +
                    "\n1 - Next week" +
                    "\n2 - Next 2 weeks" +
                    "\n3 - Next 3 weeks" +
                    "\n4 - Particular date" +
                    "\n0 - Go back");
                Console.Write("Choose an action:");
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
                }
                else if (dateChoice == "0")
                    Search(performances);
                else
                {
                    Console.WriteLine("Invalid input data. Try Again");
                    Search(performances);
                }
            }
            else if (choice == "0")
                MyMain(performances);
            else
            {
                Console.WriteLine("Invalid input data. Try Again");
                Search(performances);
            }
            if (!foundPerformances)
            {
                Console.WriteLine("No Performances found. Try something else");
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
