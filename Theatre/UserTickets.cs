namespace Theatre
{
    public class UserTickets
    {
        public uint ID;
        Tickets.TicketsTypes ticketsType;
        public UserTickets(uint ID, Tickets.TicketsTypes ticketsType)
        {
            this.ticketsType = ticketsType;
            this.ID = ID;
        }
    }
}
