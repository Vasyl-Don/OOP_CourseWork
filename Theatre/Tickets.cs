namespace Theatre
{
    public class Tickets
    {
        readonly uint totalNumberOfTickets;
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
        public TicketsTypes TicketsType { get; private set; }
        public Tickets(TicketsTypes ticketsType, uint totalNumberOfTickets, decimal price)
        {
            TicketsType = ticketsType;
            this.totalNumberOfTickets = totalNumberOfTickets;
            Price = price;
            ReservedTickets = 0;
            SoldTickets = 0;
        }
    }
}
