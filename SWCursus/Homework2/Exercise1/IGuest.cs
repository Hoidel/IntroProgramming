using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Exercise1
{

    /*
     * Every Guest has two aspects, 
     * 1: A name 
     * 2: The amount of days the guest is staying for.
     * 
     * Both of these values should be Set in the Constructor;
     */
    public interface IGuest
    {
        public string Name { get; }
        public int DaysLeftInStay { get; set; }
    }
}
