namespace Theatre
{
    public class UserTickets
    {
        public uint ID { get; private set; }
        private Tickets.TicketsTypes ticketsType;
        public uint OwnReservedTickets { get; internal set; }
        public uint OwnTickets { get; internal set; }
        public UserTickets(uint ID, Tickets.TicketsTypes ticketsType)
        {
            this.ticketsType = ticketsType;
            this.ID = ID;
        }
    }
}
