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
        public uint ReservedTickets { get; private set; }
        public uint SoldTickets { get; private set; }
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
        public void Sell(uint numberOfTickets)
        {
            if (numberOfTickets > AvailableTickets)
                throw new Exception("We don't have so many tickets");
            else SoldTickets += numberOfTickets;
        }
        public void Reserve(uint numberOfTickets)
        {
            if (numberOfTickets > AvailableTickets)
                throw new Exception("We don't have so many tickets");
            else ReservedTickets += numberOfTickets;
        }
        public void SellReserved(uint numberOfTickets)
        {
            if (numberOfTickets > ReservedTickets)
                throw new Exception("There are too few reserved tickets");
            else
            {
                ReservedTickets -= numberOfTickets;
                SoldTickets += numberOfTickets;
            }
        }
    }
}
