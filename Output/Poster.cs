using System;
using System.Collections.Generic;
using Theatre;

namespace Output
{
    class Poster
    {
        static void Main()
        {
            List<Performance> performances = new List<Performance>();
            FillList(performances);

            Console.WriteLine("Hello! It's a theater poster program. Here you can buy or book tickets to one of our performances");
            
            Start(performances);

            try
            {
                SearchById(performances);
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("No performances found. Try something else");
            }

            Console.WriteLine("\n====================================\nCurrent End");
        }

        static void Start(List<Performance> performances)
        {
            Console.WriteLine("1 - Show full list of performances" +
    "\n2 - Searching System");
            string choice = Console.ReadLine();
            if (choice == "1" || choice == "2")
            {
                if (choice == "1")
                    ShowFullList(performances);
                Search(performances);
            }
            else
            {
                Console.WriteLine("Invalid input data. Try Again");
                Start(performances);
            }
        }
        static void Search(List<Performance> performances)
        {
            Console.WriteLine("\nWhat do you want to search by?");
            Console.WriteLine("1 - Author\n2 - Name\n3 - Genre\n4 - Date");
            string choice = Console.ReadLine();

            if (choice == "1" || choice == "2" || choice == "3")
            {
                Console.Write("Input your parameter: ");
                string parameter = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        foreach (Performance p in performances)
                            if (p.Author == parameter)
                                ShowInfo(p);
                        break;
                    case "2":
                        foreach (Performance p in performances)
                            if (p.Name == parameter)
                                ShowInfo(p);
                        break;
                    case "3":
                        Enum.TryParse(parameter, out Performance.Genres genre);
                        foreach (Performance p in performances)
                            if (p.Genre == genre)
                                ShowInfo(p);
                        break;
                }
            }
            else if(choice == "4")
            {
                Console.WriteLine("Show performances for:\n1 - Next week\n2 - Next 2 weeks\n3 - Next 3 weeks\n4 - Particular date");
                string weeks = Console.ReadLine();
                if (weeks == "1" || weeks == "2" || weeks == "3")
                {
                    foreach (Performance p in performances)
                    {
                        if (p.Date - DateTime.Now <= new TimeSpan(7 * int.Parse(weeks), 0, 0, 0))
                            ShowInfo(p);
                    }
                }
                else if (weeks == "4")
                {
                    Console.Write("Input date: ");
                    DateTime.TryParse(Console.ReadLine(), out DateTime date);
                    foreach (Performance p in performances)
                    {
                        if (p.Date == date)
                            ShowInfo(p);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input data. Try Again");
                    Search(performances);
                }
            }
            else
            {
                Console.WriteLine("Invalid input data. Try Again");
                Search(performances);
            }
        }
        static void SearchById(List<Performance> performances)
        {
            Console.Write("Input the id: ");
            int id = int.Parse(Console.ReadLine());
            ShowInfo(performances[id]);
        }
        static void FillList(List<Performance> performances)
        {
            performances.Add(new Performance("William Shakespeare", "Romeo and Juliett", Performance.Genres.Tragedy, new DateTime(2021, 6, 18)));
            performances.Add(new Performance("William Shakespeare", "Gamlet", Performance.Genres.Tragedy, new DateTime(2021, 6, 19)));
            performances.Add(new Performance("Ivan Franko", "Stolen Happiness", Performance.Genres.Drama, new DateTime(2021, 6, 25)));
            performances.Add(new Performance("Mykola Kulish", "Myna Mazailo", Performance.Genres.Comedy, new DateTime(2021, 6, 26)));
            performances.Add(new Performance("Ivan Kotlyarevsky", "Natalka Poltavka", Performance.Genres.Drama, new DateTime(2021, 7, 2)));
            performances.Add(new Performance("William Shakespeare", "Midsummer Night's Dream", Performance.Genres.Comedy, new DateTime(2021, 7, 3)));
            performances.Add(new Performance("Erich Remarque", "Three Comrades", Performance.Genres.Drama, new DateTime(2021, 7, 3)));
            performances.Add(new Performance("Bernard Shaw", "Pygmalion", Performance.Genres.Comedy, new DateTime(2021, 7, 4)));
            performances.Add(new Performance("William Shakespeare", "King Lear", Performance.Genres.Tragedy, new DateTime(2021, 7, 11)));
        }
        /// <summary>
        /// Prints information about a Performance
        /// </summary>
        static void ShowInfo(Performance performance)
        {
            Console.WriteLine("\nName: " + performance.Name);
            Console.WriteLine("Author: " + performance.Author);
            Console.WriteLine("Genre: " + performance.Genre);
            Console.WriteLine("Date: " + performance.Date.ToString("d"));
            Console.WriteLine("ID: " + performance.ID);
            Console.WriteLine("Available tickets: ");
            foreach (Tickets t in performance.tickets)
                Console.WriteLine(t.ticketsType + ": " + t.AvailableTickets + "\t\tPrice: " + t.Price);
        }
        static void ShowFullList(List<Performance> list)
        {
            foreach (Performance p in list)
                ShowInfo(p);
        }
    }
}
