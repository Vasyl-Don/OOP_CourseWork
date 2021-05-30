using System;

namespace Theatre
{
    public class Tickets
    {
        private uint totalNumberOfTickets;
        public uint AvailableTickets
        {
            get { return totalNumberOfTickets - ReservedTickets - SoldTickets; }
            set { }
        }
        public uint ReservedTickets { get; internal set; }
        public uint SoldTickets { get; internal set; }
        public decimal Price { get; }
        public enum TicketsTypes
        {
            Parter,
            Amphitheater,
            Balcony
        }
        public TicketsTypes ticketsType;
        public Tickets(TicketsTypes ticketsType, uint totalNumberOfTickets, decimal price)
        {
            this.ticketsType = ticketsType;
            this.totalNumberOfTickets = totalNumberOfTickets;
            Price = price;
            ReservedTickets = 0;
            SoldTickets = 0;
        }
    }
}
