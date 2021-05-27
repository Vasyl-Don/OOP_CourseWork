using System;
using System.Collections.Generic;

namespace Theatre
{
    public class Performance
    {
        public enum Genres
        {
            Comedy = 1,
            Tragedy = 2,
            Drama = 3
        }
        public List<Tickets> tickets = new List<Tickets>()
        {
            new Tickets(Tickets.TicketTypes.Parter),
            new Tickets(Tickets.TicketTypes.Amphitheater),
            new Tickets(Tickets.TicketTypes.Balcony)
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
            tickets[typeOfTickets - 1].Sell(numberOfTickets);
        }
        public void ShowInfo()
        {
            Console.WriteLine("\nName: " + Name);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Genre: " + Genre);
            Console.WriteLine("Date: " + Date.ToString("d"));
            Console.WriteLine("Available tickets: ");
            foreach (Tickets t in tickets)
                Console.WriteLine(t.ticketsType + ": " + t.AvailableTickets + "\t\tPrice: " + t.Price);
        }
    }
}
