using System;
using System.Collections.Generic;
using Theatre;

namespace Poster
{
    public class Output
    {
        public static void ShowInfo(Performance performance)
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
        public static void ShowFullList(List<Performance> performances)
        {
            foreach (Performance p in performances)
                ShowInfo(p);
        }
        public static void ShowUserTickets(List<UserTickets> tickets)
        {
            Console.WriteLine($"You have tickets for {tickets.Count} performances");
            foreach (UserTickets t in tickets)
            {
                Console.WriteLine(" = = = = = = = = = = = = = = = = = =");
                Console.WriteLine("Performance ID: " + t.ID);
                Console.WriteLine("Type of seats: " + t.TicketsType);
                Console.WriteLine($"You have got {t.NumberOfTickets} tickets");
                Console.WriteLine(" = = = = = = = = = = = = = = = = = =");
            }
        }
    }
}
