using System;
using System.IO;

namespace BookingSystem
{
    public class Film : ILab
    {
        public string rating;
        public int runTime;
        public int price;
        public string name;

        public Film()
        {
            price = 0;
            name = "";
            runTime = 0;
            rating = "";
        }
        public Film(string rat,string name,int pr,int time)
        {
            rating = rat;
            this.name = name;
            price = pr;
            runTime = time;
        }
        public Film(Film copy)
        {
            rating = copy.rating;
            name = copy.name;
            price = copy.price;
            runTime = copy.runTime;
        }
        public void FOut(StreamWriter br)
        {
            br.WriteLine(rating);
            br.WriteLine(runTime);
            br.WriteLine(price);
            br.WriteLine(name);
        }
        public void Out()
        {
            Console.WriteLine(this.ToString());
        }
        public void In()
        {
            Console.WriteLine("Enter film name:");
            this.name = Console.ReadLine();
            Console.WriteLine("Enter film running time:");
            this.runTime = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ticket price:");
            this.price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter age rating:");
            this.rating = Console.ReadLine();
        }
        public void FIn(StreamReader br)
        {
            rating = br.ReadLine();
            runTime = int.Parse(br.ReadLine());
            price = int.Parse(br.ReadLine());
            name = br.ReadLine();
        }
        public override string ToString()
        {
            return "\nFilm name: "+name+"\nFilm price: "+price+"\nFilm running time "+runTime +
                " minutes\nFilm rating: "+rating; 
        }
    }
}
