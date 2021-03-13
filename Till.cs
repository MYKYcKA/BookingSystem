using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BookingSystem
{
    class Till
    {
        public Schedule schedule;
        List<RegularViewer> rating;
        public static void Main()
        {
            Film film = new Film("R", "Blade Runner", 65, 110);
            Film film2 = new Film("R", "Taxi Driver", 70, 130);
            Film film3 = new Film("R", "Pulp Fiction", 80, 150);
            Schedule sch=new Schedule("Monday",film);
            sch.AddSession(film2);
            sch.AddSession(film3);
            Console.WriteLine("Lab 8,9");
            Till till = new Till(sch);
            RegularViewer a = new RegularViewer();
            NamedTicket tick=new NamedTicket ();
            tick.In();
            RegularViewer b = new RegularViewer(140,tick,"Chipka");
            RegularViewer c = new RegularViewer(b);
            Viewer d = new Viewer(150);
            Console.WriteLine("\nRegular viewer a:");
            a.Out();
            Console.WriteLine("\nRegular viewer b:");
            b.Out();
            Console.WriteLine("\nRegular viewer c:");
            c.Out();
            Console.WriteLine("\nViewer d:");
            d.Out();
            till.SellTicket(d);
            till.SellTicket(b);
            Console.WriteLine("\nRegular viewer b:");
            b.Out();
            Console.WriteLine("\nViewer d:");
            d.Out();
            StreamWriter bw = new StreamWriter((new FileStream("LabText.txt", FileMode.OpenOrCreate)));
            b.FOut(bw);
            bw.Close();
            StreamReader br = new StreamReader((new FileStream("LabText.txt", FileMode.Open)));
            a.FIn(br);
            br.Close();
            Console.WriteLine("\nRegular viewer a:");
            a.Out();
            till.Polymorph(a);
            till.Polymorph(d);
            a.Unique();
            d.Unique();
            c.name = "Bohdan";
            till.AddToRating(b);
            till.AddToRating(c);
            till["Bohdan"].ticket.Out();
            Console.WriteLine(b > c);
            Console.WriteLine(till.First().name);
            till.SortRating();
            Console.WriteLine(till.First().name);
        }
        public Till()
        {
            schedule = new Schedule();
            rating = new List<RegularViewer>();
        }
        public Till(Schedule a,List<RegularViewer> b)
        {
            schedule = new Schedule(a);
            rating = new List<RegularViewer>(b);
        }
        public Till(Schedule a) : this(a, new List<RegularViewer>()) { }
        public Till(List<RegularViewer> b) : this(new Schedule(), b) { }
        public Till(Till a)
        {
            schedule = new Schedule(a.schedule);
            rating = new List<RegularViewer>(a.rating);
        }
        public void SellTicket(Viewer person)
        {
            bool temp = false;
            schedule.Out();
            Console.WriteLine("Choose film");
            string wantedfilm= Console.ReadLine();
            Console.WriteLine("Choose row");
            int wantedrow = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose place");
            int wantedplace=int.Parse(Console.ReadLine()); 
            foreach (var i in schedule.timetab)
                if (i.Item3.name == wantedfilm)
                {
                    while (i.Item4.IsSold(wantedrow, wantedplace)) 
                    {
                        Console.WriteLine("Choose row(print \'0\' to exit)");
                        wantedrow = int.Parse(Console.ReadLine());
                        if (wantedrow == 0)
                            break;
                        Console.WriteLine("Choose place");
                        wantedplace = int.Parse(Console.ReadLine());
                    }
                    if(wantedrow == 0)
                    {
                        Console.WriteLine("Your place is already sold");
                        break;
                    }
                    int filmprice = (int)(i.Item3.price * i.Item4.SeatCoef(wantedrow, wantedplace));
                    Console.WriteLine("Ticket price is {0}. Do you want to buy it?(yes/no)", filmprice);
                    string answer = Console.ReadLine();
                    if (answer!="yes"||person.cash<filmprice)
                    {
                        Console.WriteLine("Have a nice day");
                        break;
                    }
                    person.ticket = new Ticket
                    {
                        price = filmprice,
                        row = wantedrow,
                        place = wantedplace,
                        film = i.Item3.name,
                        time = i.Item1.ToString("hh\\:mm") + '-' + i.Item2.ToString("hh\\:mm")
                    };
                    person.cash -= filmprice;
                    i.Item4.SellPlace(wantedrow, wantedplace);
                    Console.WriteLine("Thanks. You'r welcome");
                    temp = true;
                }
            if (!temp) 
                    Console.WriteLine("Cannot find your film in schedule");
        }
        public void SellTicket(RegularViewer person)
        {
            bool temp = false;
            schedule.Out();
            Console.WriteLine("Choose film");
            string wantedfilm = Console.ReadLine();
            Console.WriteLine("Choose row");
            int wantedrow = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose place");
            int wantedplace = int.Parse(Console.ReadLine());
            foreach (var i in schedule.timetab)
                if (i.Item3.name == wantedfilm)
                {
                    while (i.Item4.IsSold(wantedrow, wantedplace))
                    {
                        Console.WriteLine("Choose row(print \'0\' to exit)");
                        wantedrow = int.Parse(Console.ReadLine());
                        if (wantedrow == 0)
                            break;
                        Console.WriteLine("Choose place");
                        wantedplace = int.Parse(Console.ReadLine());
                    }
                    if (wantedrow == 0)
                    {
                        Console.WriteLine("Your place is already sold");
                        break;
                    }
                    int filmprice = (int)(i.Item3.price * i.Item4.SeatCoef(wantedrow, wantedplace));
                    Console.WriteLine("Ticket price is {0}. Do you want to buy it?(yes/no)", filmprice);
                    string answer = Console.ReadLine();
                    if (answer != "yes" || person.cash == 0)
                    {
                        Console.WriteLine("Have a nice day");
                        break;
                    }
                    person.ticket = new NamedTicket
                    {
                        name = person.name,
                        price = filmprice,
                        row = wantedrow,
                        place = wantedplace,
                        film = i.Item3.name,
                        time = i.Item1.ToString("hh\\:mm") + '-' + i.Item2.ToString("hh\\:mm")
                    };
                    person.cash -= filmprice;
                    person.tickets++;
                    i.Item4.SellPlace(wantedrow, wantedplace);
                    Console.WriteLine("Thanks. You'r welcome");
                }
            if (!temp)
                Console.WriteLine("Cannot find your film in schedule");
        }
        public void AddToRating(RegularViewer a)
        {
            this.rating.Add(a);
        }
        public void SortRating()
        {
            this.rating.Sort();
        }
        public RegularViewer First()
        {
            return this.rating.First();
        }
        public RegularViewer this[int index]
        {
            get
            {
                return rating[index];
            }
            set
            {
                rating[index] = value;
            }
        }
        public RegularViewer this[string index]
        {
            get
            {
                return rating.Find(x => x.name == index);
            }
        }
        public void Polymorph(AbstractViewer abs)
        {
            Console.WriteLine("Polymorphic method in action");
        }
    }
}
