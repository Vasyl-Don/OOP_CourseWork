using System;
using System.Collections.Generic;
using Theatre;

namespace Poster
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello! It is theater poster program. You can buy/reserve tickets for performances with it");
            List<Performance> performances = new List<Performance>();
            FillList(performances);
            User user = new User();
            while(true)
            {
                Menu(user, performances);
            }
        }
        static void Menu(User user, List<Performance> performances)
        {
            Console.WriteLine("\n1 - Show full list of performances" +
                "\n2 - Searching system" +
                "\n3 - Buy tickets" +
                "\n4 - Reserve tickets" +
                "\n5 - Buy reserved tickets" +
                "\n6 - Show my tickets" +
                "\n7 - Show my reserved tickets" +
                "\n0 - Exit program");
            Console.Write("Choose an action: ");
            string choice = Console.ReadLine();
            if (int.TryParse(choice, out int intChoice))
            {
                switch (intChoice)
                {
                    case 1:
                        Output.ShowFullList(performances);
                        break;
                    case 2:
                        Search(performances);
                        break;
                    case 3:
                        CashRegister.BuyingTickets(user, performances);
                        break;
                    case 4:
                        CashRegister.ReservisingTickets(user, performances);
                        break;
                    case 5:
                        CashRegister.BuyingReservedTickets(user, performances);
                        break;
                    case 6:
                        Console.WriteLine("\nYour tickets:");
                        Output.ShowUserTickets(user.ownTickets);
                        break;
                    case 7:
                        Console.WriteLine("\nYour reserved tickets:");
                        Output.ShowUserTickets(user.ownReservedTickets);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input data. Try again");
                        break;
                }
            }
            else Console.WriteLine("Invalid input data. Try again");
        }
        static void Search(List<Performance> performances)
        {
            Console.WriteLine("\nWhat do you want to search by?");
            Console.WriteLine("1 - Author\n2 - Name\n3 - Genre\n4 - ID\n5 - Date\n0 - Go back");
            Console.Write("Choose an action: ");
            string choice = Console.ReadLine();
            bool foundPerformances = false;
            if(int.TryParse(choice, out int intChoice))
            {
                if (intChoice >= 0 && intChoice < 5)
                {
                    Console.Write("Input your parameter: ");
                    string parameter = Console.ReadLine();
                    switch (intChoice)
                    {
                        case 1:
                            foreach (Performance p in performances)
                                if (p.Author == parameter)
                                {
                                    Output.ShowInfo(p);
                                    foundPerformances = true;
                                }
                            break;
                        case 2:
                            foreach (Performance p in performances)
                                if (p.Name == parameter)
                                {
                                    Output.ShowInfo(p);
                                    foundPerformances = true;
                                }
                            break;
                        case 3:
                            Enum.TryParse(parameter, out Genres genre);
                            foreach (Performance p in performances)
                                if (p.Genre == genre)
                                {
                                    Output.ShowInfo(p);
                                    foundPerformances = true;
                                }
                            break;
                        case 4:
                            if (int.Parse(parameter) > 0 && int.Parse(parameter) <= performances.Count)
                            {
                                foundPerformances = true;
                                Output.ShowInfo(performances[int.Parse(parameter) - 1]);
                            }
                            break;
                        case 0:
                            break;
                    }
                    if (!foundPerformances)
                        Console.WriteLine("No Performances found. Try something else");
                }
                else if(intChoice == 5)
                {
                    Console.WriteLine("Show performances for:" +
                    "\n1 - Next week" +
                    "\n2 - Next 2 weeks" +
                    "\n3 - Next 3 weeks" +
                    "\n4 - Particular date" +
                    "\n0 - Go back");
                    Console.Write("Choose an action: ");
                    string dateChoice = Console.ReadLine();
                    if (int.TryParse(dateChoice, out int intDateChoice))
                    {
                        if (intDateChoice >= 0 && intDateChoice < 4)
                        {
                            foreach (Performance p in performances)
                            {
                                if (p.Date - DateTime.Now <= new TimeSpan(7 * intDateChoice, 0, 0, 0))
                                {
                                    Output.ShowInfo(p);
                                    foundPerformances = true;
                                }
                            }
                        }
                        else if (intDateChoice == 4)
                        {
                            Console.Write("Input date: ");
                            DateTime.TryParse(Console.ReadLine(), out DateTime date);
                            foreach (Performance p in performances)
                            {
                                if (p.Date == date)
                                {
                                    Output.ShowInfo(p);
                                    foundPerformances = true;
                                }
                            }
                            if (!foundPerformances)
                                Console.WriteLine("No Performances found. Try something else");
                        }
                        else if (intDateChoice == 0)
                            Search(performances);
                        else
                        {
                            Console.WriteLine("Invalid input data. Try Again");
                            Search(performances);
                        }
                    }
                    else
                        Console.WriteLine("Invalid input. Try again");
                }
                else Console.WriteLine("Invalid input. Try again");
            }
            else
            {
                Console.WriteLine("Invalid input data. Try Again");
                Search(performances);
            }
        }
        static void FillList(List<Performance> performances)
        {
            performances.Add(new Performance("William Shakespeare", "Romeo and Juliett", Genres.Tragedy, new DateTime(2021, 6, 18), 400, 300, 500));
            performances.Add(new Performance("William Shakespeare", "Gamlet", Genres.Tragedy, new DateTime(2021, 6, 19), 450, 350, 550));
            performances.Add(new Performance("Ivan Franko", "Stolen Happiness", Genres.Drama, new DateTime(2021, 6, 25), 350, 250, 400));
            performances.Add(new Performance("Mykola Kulish", "Myna Mazailo", Genres.Comedy, new DateTime(2021, 6, 26), 350, 250, 400));
            performances.Add(new Performance("Ivan Kotlyarevsky", "Natalka Poltavka", Genres.Drama, new DateTime(2021, 7, 2), 400, 225, 450));
            performances.Add(new Performance("William Shakespeare", "Midsummer Night's Dream", Genres.Comedy, new DateTime(2021, 7, 3), 320, 250, 350));
            performances.Add(new Performance("Erich Remarque", "Three Comrades", Genres.Drama, new DateTime(2021, 7, 3), 325, 300, 380));
            performances.Add(new Performance("Bernard Shaw", "Pygmalion", Genres.Comedy, new DateTime(2021, 7, 4), 350, 325, 400));
            performances.Add(new Performance("William Shakespeare", "King Lear", Genres.Tragedy, new DateTime(2021, 7, 11), 400, 325, 450));
        }
    }
}
