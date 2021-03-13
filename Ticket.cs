using System;
using System.IO;

namespace BookingSystem
{
    public struct Ticket :ILab
    {
        public int price;
        public string film;
        public string time;
        public int row;
        public int place;
        public override string ToString()
        {
            return string.Format("\nFilm name: {0}\nPrice: {1}\nTime: {2}\nPlace: row {3} seat {4}",
                film, price, time, row, place);
        }
        public void Out()
        {
            Console.WriteLine(this.ToString());
        }
        public void FOut(StreamWriter br)
        {
            br.WriteLine(price);
            br.WriteLine(film);
            br.WriteLine(time);
            br.WriteLine(row);
            br.WriteLine(place);
        }
        public void FIn(StreamReader br)
        {
            price = int.Parse(br.ReadLine());
            film = br.ReadLine();
            time = br.ReadLine();
            row = int.Parse(br.ReadLine());
            place = int.Parse(br.ReadLine());
        }
        public void In()
        {
            Console.WriteLine("Enter price:");
            price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter film name:");
            film = Console.ReadLine();
            Console.WriteLine("Enter time span:");
            time = Console.ReadLine();
            Console.WriteLine("Enter row:");
            row = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter place:");
            place = int.Parse(Console.ReadLine());
        }
    }
}
