using System;
using System.IO;

namespace BookingSystem
{
    public sealed class RegularViewer : Viewer,IComparable<RegularViewer>,IEquatable<RegularViewer>
    {
        private int ticketCount;
        public string name;
        public new NamedTicket ticket;
        public int tickets
        {
            get => ticketCount;
            set => ticketCount = value;
        }
        public RegularViewer()
        {
            ticket = new NamedTicket { price = 0,film="",name="",row=0,place=0,time=""};
            name = "";
            tickets = 1;
        }
        public RegularViewer(int money, NamedTicket tick, string name):base(money)
        {
            this.name = name;
            ticket = tick;
            tickets=1;
        }
        public RegularViewer(RegularViewer b) : base(b)
        {
            name = b.name;
            ticket = b.ticket;
        }
        public override string ToString()
        {
            return string.Format("\nViewer name: {0}\nCurrent viewer cash: {1}\nNumber of bought tickets: {2}" +
                "\nCurrent ticket:\n{3}"
                , name,money, tickets, ticket.ToString());
        }
        public new void Out()
        {
            Console.WriteLine(this.ToString());
        }
        public new void FOut(StreamWriter br)
        {
            br.WriteLine(money);
            ticket.FOut(br);
            br.WriteLine(name);
        }
        public new void FIn(StreamReader br)
        {
            money = int.Parse(br.ReadLine());
            ticket.FIn(br);
            name = br.ReadLine();
        }
        public new void In()
        {
            base.In();
            name = Console.ReadLine();
        }
        public new void Unique()
        {
            Console.WriteLine("Unique method for RegularViewer class");
        }
        public int CompareTo(RegularViewer other) { return ticketCount.CompareTo(other.ticketCount); }

        public  bool Equals(RegularViewer other)
        {
            return ticketCount == other.ticketCount;
        }
        public override bool Equals(Object other)
        {
            return Equals(other as RegularViewer);
        }
        public override int GetHashCode()
        {
            return ticketCount.GetHashCode() ^ name.GetHashCode() ^ ticket.GetHashCode();
        }

        public static bool operator ==(RegularViewer a, RegularViewer b) => a.Equals(b);
        public static bool operator !=(RegularViewer a, RegularViewer b) => !a.Equals(b);
        public static bool operator >(RegularViewer a, RegularViewer b) => a.ticketCount > b.ticketCount;
        public static bool operator <(RegularViewer a, RegularViewer b) => a.ticketCount < b.ticketCount;
    }
}
