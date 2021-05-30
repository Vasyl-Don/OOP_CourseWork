using System;
using System.Collections.Generic;
using Theatre;

namespace Afisha
{
    class User
    {
        public List<Performance> tickets = new List<Performance>();

        public void ShowMyTickets()
        {
            Console.WriteLine($"You have tickets for {tickets.Count} performances:");
        }
    }
}
