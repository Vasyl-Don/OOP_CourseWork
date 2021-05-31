using System;
using System.Collections.Generic;

namespace Theatre
{
    public class Performance
    {
        public enum Genres
        {
            Comedy,
            Tragedy,
            Drama
        }
        public List<Tickets> tickets;
        private static uint id;
        public uint ID { get; private set; }
        public string Author { get; private set; }
        public string Name { get; private set; }
        public Genres Genre { get; private set; }
        public DateTime Date { get; private set; }
        static Performance()
        {
            id = 0;
        }
        public Performance(string Author, string Name, Genres Genre, DateTime Date, decimal parterPrice, decimal amphitheaterPrice, decimal balconyPrice)
        {
            id += 1;
            ID = id;
            this.Author = Author;
            this.Name = Name;
            this.Genre = Genre;
            this.Date = Date;
            tickets = new List<Tickets>()
            {
                new Tickets(Tickets.TicketsTypes.Parter, 300, parterPrice),
                new Tickets(Tickets.TicketsTypes.Amphitheater, 150, amphitheaterPrice),
                new Tickets(Tickets.TicketsTypes.Balcony, 50, balconyPrice)
            };
        }
        public void SellTickets(int ticketsType, uint numberOfTickets)
        {
            tickets[ticketsType].SoldTickets += numberOfTickets;
        }
        public void ReserveTickets(int ticketsType, uint numberOfTickets)
        {
            tickets[ticketsType].ReservedTickets += numberOfTickets;
        }
        public void SellReservedTickets(int ticketsType, uint numberOfTickets)
        {
            tickets[ticketsType].ReservedTickets -= numberOfTickets;
            tickets[ticketsType].SoldTickets += numberOfTickets;
        }
    }
}
