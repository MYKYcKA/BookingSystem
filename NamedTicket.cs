using System;
using System.IO;

namespace BookingSystem
{
    public struct NamedTicket:ILab
    {
        public int price;
        public string film;
        public string time;
        public int row;
        public int place;
        public string name;
        public override string ToString()
        {
            return string.Format("\nFilm name: {0}\nPrice: {1}\nTime: {2}\nPlace: row {3} seat {4}\nYour name: {5}",
                film, price, time, row, place,name);
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
            br.WriteLine(name);
        }
        public void FIn(StreamReader br)
        {
            price = int.Parse(br.ReadLine());
            film = br.ReadLine();
            time = br.ReadLine();
            row = int.Parse(br.ReadLine());
            place = int.Parse(br.ReadLine());
            name = br.ReadLine();
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
            Console.WriteLine("Enter name:");
            name = Console.ReadLine();
        }
    }
}
