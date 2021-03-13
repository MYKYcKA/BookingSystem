using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookingSystem
{
    public class CinemaHall :ILab
    {
        private (bool, double)[,] seatHall = new(bool, double) [6,10];
        public CinemaHall() 
        {
            for(int i=0; i<6; i++)
                for(int j=0;j<10;j++)
                {
                    seatHall[i, j].Item1 = false;
                    seatHall[i, j].Item2 = 1;
                    if (i > 2 && i < 5 && j > 3 && j < 8) 
                        seatHall[i, j].Item2 += 0.5;
                    else
                        seatHall[i, j].Item2 += 0.25;
                }
        }
        public void Out()
        {
            Console.WriteLine(this.ToString());
        }
        public void FOut(StreamWriter br)
        {
            foreach ((bool, double) i in seatHall)
            {
                br.WriteLine(i.Item1);
                br.WriteLine(i.Item2);
            }
        }
        public void FIn(StreamReader br)
        {
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 10; j++)
                {
                    this.seatHall[i, j].Item1 = bool.Parse(br.ReadLine());
                    this.seatHall[i, j].Item2 = double.Parse(br.ReadLine());
                }
        }
        public void In()
        {
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 10; j++)
                {
                    Console.WriteLine("Enter state(true\\false) and coef(double) for place {0} row {1}. ", i + 1, j + 1);
                    this.seatHall[i, j].Item1 = bool.Parse(Console.ReadLine());
                    this.seatHall[i, j].Item2 = double.Parse(Console.ReadLine());
                }
        }
        public bool IsSold(int row,int place)
        {
            return seatHall[row-1, place-1].Item1;
        }
        public double  SeatCoef(int row, int place)
        {
            return seatHall[row - 1, place - 1].Item2;
        }
        public void SellPlace(int row,int place)
        {
            seatHall[row - 1, place - 1].Item1 = true;
        }
       
        public override string ToString()
        {
            string Hall;
            Hall = string.Format("\n{0,-7}", "");
            for (int i = 0; i < 10; i++)
                Hall += string.Format("seat {0,-6}", i + 1);
            for (int i = 0; i < 6; i++)
            {
                Hall += string.Format("\nrow {0}:", i + 1);
                for (int j = 0; j < 10; j++)
                {
                    if (seatHall[i, j].Item1)
                        Hall += string.Format("{0,-11}", " sold");
                    else
                        Hall += string.Format("{0,-11}", " avaliable");
                }
            }
            Hall += '\n';
            return Hall;
        }
    }
}
