using System;

namespace Kursach_alpha
{
    public class Tickets
    {
        public uint TotalNumberOfTickets;
        public uint AvailableTickets
        {
            get { return TotalNumberOfTickets - ReservedTickets - SoldTickets; }
            set { }
        }
        public uint ReservedTickets = 0;
        public uint SoldTickets = 0;
        public decimal Price { get; }
        public enum TicketsType : int
        {
            Parter = 1,
            Amphitheater = 2,
            Balcony = 3
        }
        public TicketsType TicketType;

        public Tickets(TicketsType ticketsType)
        {
            TicketType = ticketsType;
            switch (ticketsType)
            {
                case TicketsType.Parter:
                    TotalNumberOfTickets = 350;
                    Price = 400;
                    break;
                case TicketsType.Amphitheater:
                    TotalNumberOfTickets = 100;
                    Price = 250;
                    break;
                case TicketsType.Balcony:
                    TotalNumberOfTickets = 50;
                    Price = 500;
                    break;
            }
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
