using System;
using System.Collections.Generic;

namespace Theatre
{
    public class Performance
    {
        public List<Tickets> tickets;
        private static uint id;
        public uint ID { get; }
        public string Author { get; }
        public string Name { get; }
        public Genres Genre { get; }
        public DateTime Date { get; }
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
                new Tickets(TicketsTypes.Parter, 300, parterPrice),
                new Tickets(TicketsTypes.Amphitheater, 150, amphitheaterPrice),
                new Tickets(TicketsTypes.Balcony, 50, balconyPrice)
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
