using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre
{
    public static class CashRegister
    {
        public static void BuyingTickets(User user, List<Performance> performances)
        {
            Console.Write("\nInput an ID of performance: ");
            uint.TryParse(Console.ReadLine(), out uint ID);
            if (ID > 0 && ID < performances.Count)
            {
                Performance currentPerformance = performances[Convert.ToInt32(ID) - 1];
                Output.ShowInfo(currentPerformance);

                Console.Write("Choose type of seats\n1 - Parter\n2 - Amphitheater\n3 - Balcony\n0 - Cancel\nInput a number: ");
                string input = Console.ReadLine();

                int.TryParse(input, out int ticketsType);
                if (ticketsType > 0 && ticketsType < 4)
                {
                    ticketsType--;
                    Enum.TryParse(ticketsType.ToString(), out Tickets.TicketsTypes ticketsEnumType);

                    Console.Write("How many tickets do you want to buy: ");
                    uint numberOfTickets = uint.Parse(Console.ReadLine());

                    Console.WriteLine($"You are going to buy {numberOfTickets} {ticketsEnumType} tickets. It will cost you {numberOfTickets * currentPerformance.tickets[ticketsType].Price} UAH. Are you sure?");
                    Console.WriteLine("1 - Yes, I am sure\n0 - Cancel");
                    string answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        if (numberOfTickets > 0 && numberOfTickets <= currentPerformance.tickets[ticketsType].AvailableTickets)
                        {
                            user.AddTickets(user.ownTickets, ID, ticketsEnumType, numberOfTickets);
                            currentPerformance.SellTickets(ticketsType, numberOfTickets);
                        }
                        else
                            Console.WriteLine("We don't have that number of tickets. Try something else");
                    }
                    else
                        Console.WriteLine("Operation canceled");
                }
                else
                    Console.WriteLine("Invalid input. Try again");
            }
            else
            {
                Console.WriteLine("No performance found. Try something else");
            }
        }
        public static void ReservisingTickets(User user, List<Performance> performances)
        {
            Console.Write("\nInput an ID of performance: ");
            uint.TryParse(Console.ReadLine(), out uint ID);
            if (ID > 0 && ID < performances.Count)
            {
                Performance currentPerformance = performances[Convert.ToInt32(ID) - 1];
                Output.ShowInfo(currentPerformance);

                Console.Write("Choose type of seats\n1 - Parter\n2 - Amphitheater\n3 - Balcony\n0 - Cancel\nInput a number: ");
                string input = Console.ReadLine();

                int.TryParse(input, out int ticketsType);
                if (ticketsType > 0 && ticketsType < 4)
                {
                    ticketsType--;
                    Enum.TryParse(ticketsType.ToString(), out Tickets.TicketsTypes ticketsEnumType);

                    Console.Write("How many tickets do you want to reserve: ");
                    uint numberOfTickets = uint.Parse(Console.ReadLine());

                    Console.WriteLine($"You are going to reserve {numberOfTickets} {ticketsEnumType} tickets. Are you sure?");
                    Console.WriteLine("1 - Yes, I am sure\n0 - Cancel");

                    string answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        if (numberOfTickets > 0 && numberOfTickets <= currentPerformance.tickets[ticketsType].AvailableTickets)
                        {
                            user.AddTickets(user.ownReservedTickets, ID, ticketsEnumType, numberOfTickets);
                            currentPerformance.ReserveTickets(ticketsType, numberOfTickets);
                        }
                        else
                            Console.WriteLine("We don't have that number of tickets. Try something else");
                    }
                    else
                        Console.WriteLine("Operation canceled");
                }
                else
                    Console.WriteLine("Invalid input. Try again");
            }
            else
            {
                Console.WriteLine("No performance found. Try something else");
            }
        }
        public static void BuyingReservedTickets(User user, List<Performance> performances)
        {
            Console.Write("\nInput an ID of performance: ");
            uint.TryParse(Console.ReadLine(), out uint ID);
            if (ID > 0 && ID < performances.Count)
            {
                Performance currentPerformance = performances[Convert.ToInt32(ID) - 1];
                Output.ShowInfo(currentPerformance);

                Console.Write("Choose type of seats\n1 - Parter\n2 - Amphitheater\n3 - Balcony\n0 - Cancel\nInput a number: ");
                string input = Console.ReadLine();

                int.TryParse(input, out int ticketsType);
                if (ticketsType > 0 && ticketsType < 4)
                {
                    ticketsType--;
                    Enum.TryParse(ticketsType.ToString(), out Tickets.TicketsTypes ticketsEnumType);
                    UserTickets currentTickets = null;
                    foreach (UserTickets t in user.ownReservedTickets)
                    {
                        if (t.ID == ID && t.TicketsType == ticketsEnumType)
                        {
                            Console.WriteLine($"You have {t.NumberOfTickets} {t.TicketsType} tickets reserved");
                            currentTickets = t;
                        }
                    }
                    Console.Write("How many tickets do you want to buy: ");
                    uint numberOfTickets = uint.Parse(Console.ReadLine());

                    Console.WriteLine($"You are going to buy {numberOfTickets} {ticketsEnumType} tickets. It will cost you {numberOfTickets * currentPerformance.tickets[Convert.ToInt32(ticketsEnumType)].Price} UAH. Are you sure?");
                    Console.WriteLine("1 - Yes, I am sure\n0 - Cancel");
                    string answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        if (numberOfTickets > 0 && numberOfTickets <= currentTickets.NumberOfTickets)
                        {
                            user.AddTickets(user.ownTickets, ID, ticketsEnumType, numberOfTickets);
                            user.RemoveTickets(user.ownReservedTickets, ID, ticketsEnumType, numberOfTickets);
                            currentPerformance.SellReservedTickets(ticketsType, numberOfTickets);
                        }
                        else
                            Console.WriteLine("We don't have that number of tickets. Try something else");
                    }
                    else
                        Console.WriteLine("Operation canceled");
                }
                else
                    Console.WriteLine("Invalid input. Try again");
            }
            else
            {
                Console.WriteLine("No performance found. Try something else");
            }
        }
    }
}
