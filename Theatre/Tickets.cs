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
        public enum TicketTypes
        {
            Parter = 1,
            Amphitheater = 2,
            Balcony = 3
        }
        public TicketTypes ticketsType;

        public Tickets(TicketTypes ticketsType)
        {
            this.ticketsType = ticketsType;
            switch (ticketsType)
            {
                case TicketTypes.Parter:
                    totalNumberOfTickets = 350;
                    Price = 400;
                    break;
                case TicketTypes.Amphitheater:
                    totalNumberOfTickets = 100;
                    Price = 250;
                    break;
                case TicketTypes.Balcony:
                    totalNumberOfTickets = 50;
                    Price = 500;
                    break;
            }
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
