using System.Collections.Generic;
using Theatre;

namespace Afisha
{
    public class User
    {
        public List<UserTickets> ownTickets = new List<UserTickets>();
        public List<UserTickets> reservedTickets = new List<UserTickets>();
        public void AddTickets(List<UserTickets> ticketsList, uint ID, Tickets.TicketsTypes ticketsType, uint numberOfTickets)
        {
            bool ticketsExist = false;
            foreach (UserTickets t in ticketsList)
            {
                if (t.ID == ID && t.TicketsType == ticketsType)
                {
                    t.NumberOfTickets += numberOfTickets;
                    ticketsExist = true;
                }
            }
            if (!ticketsExist)
            {
                ticketsList.Add(new UserTickets(ID, ticketsType));
                AddTickets(ticketsList, ID, ticketsType, numberOfTickets);
            }
        }
    }
}
