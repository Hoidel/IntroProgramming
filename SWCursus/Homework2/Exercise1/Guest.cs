using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Exercise1
{
    public class Guest : IGuest
    {

        public string Name;
        public int DaysLeftInStay;



        public Guest(string name, int daysLeftInStay)
        {
            Name = name;
            DaysLeftInStay = daysLeftInStay;
        }

    }
}
