using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BookingSystem
{
    public class Schedule :ILab
    {
        private static int hallCounter;
        public int count { get => hallCounter; }
        public string day;
        public List<(TimeSpan, TimeSpan, Film, CinemaHall)> timetab = new List<(TimeSpan, TimeSpan, Film, CinemaHall)>();
        public Schedule()
        {
            day = "Monday";
            hallCounter++;
            timetab.Add(( new TimeSpan(8,0,0), new TimeSpan(8, 0, 0), new Film(), new CinemaHall() ));
        }
        static Schedule()
        {
            hallCounter = 0;
        }
        public Schedule(string day,Film f)
        {
            this.day = day;
            hallCounter++;
            timetab.Add((new TimeSpan(8, 0, 0), new TimeSpan(8, f.runTime, 0), f, new CinemaHall()));
        }
        public Schedule(string day) : this(day, new Film()) { }
        public Schedule(Film f) : this("Monday", f) { }
        public Schedule(Schedule copy)
        {
            this.day = copy.day;
            this.timetab = copy.timetab;
            hallCounter++;
        }

        public void AddSession(Film kl)
        {
            TimeSpan a = timetab.Last().Item2 + new TimeSpan(0, 15, 0);
            TimeSpan b = a+new TimeSpan(0,kl.runTime,0);
            if( b.Hours > 21)
                Console.WriteLine("No more sessions can be added");
            else
                timetab.Add((a,b, kl, new CinemaHall()));
        }

        public void Out()
        {
            Console.WriteLine(this.ToString());
        }
        public void FOut(StreamWriter br)
        {
            foreach((TimeSpan, TimeSpan, Film, CinemaHall) i in timetab)
            {
                br.WriteLine(i.Item1.ToString());
                br.WriteLine(i.Item2.ToString());
                i.Item3.FOut(br);
                i.Item4.FOut(br);
            }
        }
        public void FIn(StreamReader br)
        {
            for(int i=0;i<timetab.Count(); i++)
            {
                (TimeSpan, TimeSpan, Film, CinemaHall) kol = timetab[i];
                kol.Item1 = TimeSpan.Parse(br.ReadLine());
                kol.Item2 = TimeSpan.Parse(br.ReadLine());
                kol.Item3.FIn(br);
                kol.Item4.FIn(br);
                timetab[i] = kol;
            }
        }
        public void In()
        {
            for (int i = 0; i < timetab.Count(); i++)
            {
                (TimeSpan, TimeSpan, Film, CinemaHall) kol = timetab[i];
                kol.Item1 = TimeSpan.Parse(Console.ReadLine());
                kol.Item2 = TimeSpan.Parse(Console.ReadLine());
                kol.Item3.In();
                kol.Item4.In();
                timetab[i] = kol;
            }
        }
        public override string ToString()
        {
            string str = string.Format("\nDay: {0}", day);
            foreach (var i in timetab)
            {
                str+=string.Format("\nTime:{0:hh\\:mm}-{1:hh\\:mm}", i.Item1, i.Item2);
                str+=i.Item3.ToString();
                str+=string.Format("\nAvaliable places:");
                str+=i.Item4.ToString();
            }
            return str;
        }
    }
}
