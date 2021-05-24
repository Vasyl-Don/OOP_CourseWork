using System;
using System.Collections.Generic;

namespace Kursach_alpha
{
    public class Performance
    {
        public enum Genres : int
        {
            Comedy = 1,
            Tragedy = 2,
            Drama = 3,
            Ballet = 4,
            Musical = 5
        }
        public List<Tickets> Tickets = new List<Tickets>()
        {
            new Tickets(Kursach_alpha.Tickets.TicketsType.Parter),
            new Tickets(Kursach_alpha.Tickets.TicketsType.Amphitheater),
            new Tickets(Kursach_alpha.Tickets.TicketsType.Balcony)
        };
        static uint id;
        public uint ID;
        public string Author;
        public string Name;
        public Genres Genre;
        public DateTime Date;
        static Performance()
        {
            id = 0;
        }
        public Performance(string Author, string Name, Genres Genre, DateTime Date)
        {
            id += 1;
            ID = id;
            this.Author = Author;
            this.Name = Name;
            this.Genre = Genre;
            this.Date = Date;
        }
        public void BuyTicket(int typeOfTickets, uint numberOfTickets)
        {
            Tickets[typeOfTickets - 1].Sell(numberOfTickets);
        }
        public void ShowInfo()
        {
            Console.WriteLine("\nName: " + Name);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Genre: " + Genre);
            Console.WriteLine("Date: " + Date.ToString("d"));
            Console.WriteLine("Available tickets: ");
            foreach (Tickets t in Tickets)
                Console.WriteLine(t.TicketType + ": " + t.AvailableTickets + "\t\tPrice: " + t.Price);
        }
    }
}
