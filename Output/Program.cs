using System;
using System.Collections.Generic;
using Theatre;

namespace Output
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Performance> performances = new List<Performance>()
            {
                new Performance("William Shakespeare", "Romeo and Juliett", Performance.Genres.Tragedy, new DateTime (2021 , 6, 18)),
                new Performance("William Shakespeare", "Gamlet", Performance.Genres.Tragedy, new DateTime(2021, 6, 19)),
                new Performance("Ivan Franko", "Stolen Happiness", Performance.Genres.Drama, new DateTime(2021, 6, 25)),
                new Performance("Mykola Kulish", "Myna Mazailo", Performance.Genres.Comedy, new DateTime(2021, 6, 26)),
                new Performance("Ivan Kotlyarevsky", "Natalka Poltavka", Performance.Genres.Drama, new DateTime(2021, 7, 2)),
                new Performance("William Shakespeare", "Midsummer Night's Dream", Performance.Genres.Comedy, new DateTime(2021, 7, 3)),
                new Performance("Erich Remarque", "Three Comrades", Performance.Genres.Drama, new DateTime(2021, 7, 3)),
                new Performance("Bernard Shaw", "Pygmalion", Performance.Genres.Comedy, new DateTime(2021, 7, 4)),
                new Performance("William Shakespeare", "King Lear", Performance.Genres.Tragedy, new DateTime(2021, 7, 11))
            };
            
            Console.WriteLine("Hello! It's a theater poster program. Here you can buy or book a ticket to one of our performances");

        }
        static void Search()
        {
            Console.WriteLine("What do you want to search by?");
            Console.WriteLine("1 - Author\n2 - Name\n3 - Genre\n4 - Date");

        }

    }
}
