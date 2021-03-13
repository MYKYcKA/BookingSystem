using System.IO;

namespace BookingSystem
{
    interface ILab
    {
        void Out();
        void FOut(StreamWriter br);
        void In();
        void FIn(StreamReader br);
    }
}
