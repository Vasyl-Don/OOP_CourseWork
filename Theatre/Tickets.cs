using System;

namespace Theatre
{
    public class Tickets
    {
        public uint totalNumberOfTickets;
        public uint AvailableTickets
        {
            get { return totalNumberOfTickets - reservedTickets - soldTickets; }
            set { }
        }
        public uint reservedTickets = 0;
        public uint soldTickets = 0;
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
        }
        public void Sell(uint numberOfTickets)
        {
            if (numberOfTickets > AvailableTickets)
                throw new Exception("We don't have so many tickets");
            else soldTickets += numberOfTickets;
        }
        public void Reserve(uint numberOfTickets)
        {
            if (numberOfTickets > AvailableTickets)
                throw new Exception("We don't have so many tickets");
            else reservedTickets += numberOfTickets;
        }
        public void SellReserved(uint numberOfTickets)
        {
            if (numberOfTickets > reservedTickets)
                throw new Exception("There are too few reserved tickets");
            else
            {
                reservedTickets -= numberOfTickets;
                soldTickets += numberOfTickets;
            }
        }
    }
}
