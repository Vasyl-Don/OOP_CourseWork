using System.Collections.Generic;

namespace Theatre
{
    public class User
    {
        public List<UserTickets> ownTickets = new List<UserTickets>();
        public List<UserTickets> ownReservedTickets = new List<UserTickets>();
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
        public void RemoveTickets(List<UserTickets> ticketsList, uint ID, Tickets.TicketsTypes ticketsType, uint numberOfTickets)
        {
            for (int i = 0; i < ticketsList.Count; i++)
            {
                if (ticketsList[i].ID == ID && ticketsList[i].TicketsType == ticketsType)
                {
                    ticketsList[i].NumberOfTickets -= numberOfTickets;
                    if (ticketsList[i].NumberOfTickets == 0)
                        ticketsList.RemoveAt(i);
                }
            }
        }
    }
}
