namespace Theatre
{
    public class UserTickets
    {
        public uint ID { get; private set; }
        public TicketsTypes TicketsType { get; private set; }
        public uint NumberOfTickets { get; internal set; }
        public UserTickets(uint ID, TicketsTypes ticketsType)
        {
            NumberOfTickets = 0;
            TicketsType = ticketsType;
            this.ID = ID;
        }
    }
}
