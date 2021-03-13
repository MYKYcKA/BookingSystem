using System;
using System.IO;

namespace BookingSystem
{
    public class Viewer:AbstractViewer
    {
        private static int ViewerCount;
        public Viewer()
        {
            ViewerCount++;
        }
        public Viewer(int money, Ticket tick):base(money, tick)
        {
            ViewerCount++;
        }
        public Viewer(int money) : base(money) { }
        public Viewer(Viewer copy):base(copy)
        {
            ViewerCount++;
        }
        static Viewer()
        {
            ViewerCount = 0;
            Console.WriteLine("Static constructor in action");
            ViewerCount++;
        }
        public override string ToString()
        {
            return string.Format("\nNumber of viewers: {0}\nCurrent viewer cash: {1}\nCurrent ticket:\n{2}"
                , ViewerCount,money, ticket.ToString());
        }
        public void Out()
        {
            Console.WriteLine(this.ToString());
        }
        public void FOut(StreamWriter br)
        {
            br.WriteLine(money);
            ticket.FOut(br);
        }
        public void FIn(StreamReader br)
        {
            money = int.Parse(br.ReadLine());
            ticket.FIn(br);
        }
        public void In()
        {
            Console.WriteLine("Enter current viewer cash amount:");
            money = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter current viewer ticket:");
            ticket.In();
        }
        public void Unique()
        {
            Console.WriteLine("Unique method for Viewer class");
        }
    } 
}
