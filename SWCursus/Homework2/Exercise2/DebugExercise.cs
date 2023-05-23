using Homework2.Exercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Exercise2
{
    public class DebugExercises
    {
        public DebugExercises()
        { }


        public void Exercise1()
        {
            List<List<IGuest>> guestGroups = HiddenInitialize();

            /*
             * use quickwatch (shift+f9) to tell me the following things about the different groups (lists) of guests.
             * you can start with a breakpoint at line 40
             * 
             * Q: how many groups of guests are there?
             * A: -
             * 
             * Q: what is the largest group of guests 
             * A: -
             * 
             * Q: Two names occur twice in the list of guests, which two:
             * A: 
             * 
             * Q: Give me the names of all guests who stay for 3 days:
             * A: 
             * 
             * Q: There is one guest that stays for 8 days, change the amount of days that guest will stay to 7 or less
             * 
             */
           
            if (guestGroups.Any(group => group.Any(guest => guest.DaysLeftInStay > 7)))
            {
                throw new InvalidOperationException();
            }
        }


        /*
         * In this exercise we've implemented a simple Selection sort algorithm. 
         * 
         * Unfortunately I have to catch my train and don't have time to debug this, that will be up to you. 
         * 
         * There are two bugs in the code below.
         *  1: An operation is done with the wrong number. I've accedantally swapped an i and a j. But i don't know where. 
         *  2: Oops I made a mistake in an comparison (>, >=, ==, <=, <), you can probebly fix that. 
         *  
         *  Use f10 to loop trough the lines of code and keep a watch for the local values that should or shouldn't change. 
         *  
         *  You can start with a breakpoint at line 60 
         */
        public void Exercise2()
        {
            List<int> ints = new List<int>() { 14,17,9,1,19,7,18,4 };
            
            //Loop trough all numbers in the list 
            for (int i = 0; i < ints.Count; i++)
            {
                // Note the index of the currently lowest found number
                int min_i = i;

                // Loop trough all following numbers in the list. 
                for (int j = i + 1; j < ints.Count; i++)
                {
                    // if the number is smaller than the currently lowest found number store the index of the new lowest found number
                    if (ints[j] > ints[min_i])
                    {
                        min_i = j;
                    }
                }
                // if the lowest found number is not equal to the number we started with swap it out. 
                if (min_i != i)
                {
                    int temp = ints[i];
                    ints[i] = ints[min_i];
                    ints[min_i] = temp;
                }

            }
        }

        // DO NOT look at the inside of this method, I've tried my best to make it unreadable because you should get all information from the debugger
        private List<List<IGuest>> HiddenInitialize()
        {
            List<string> randoms1 = new List<string>() { "Maximilian", "Saad", "Gülşen", "Sergen", "Caithlin", "Ariade", "Jaron", "Georgina", "Noura", "Rindert", "Sigrid", "Abdellah", "Liselotte", "Everdina", "Natascha", "Martijn", "Aleksandra", "Judy", "Gijsbertje", "Albertina", "Wishal", "Christianus", "Lieven", "Diona", "Edwina" };
            List<int> randoms2 = new List<int>() { 23, 10, 20, 3, 7, 4, 11, 19, 17, 2, 20, 8, 12, 24, 14, 15, 16, 18, 0, 9, 13, 22, 7, 1, 5 };
            List<int> randoms3 = new List<int>() { 1, 2, 8, 7, 3, 3, 5, 5, 2, 3, 2, 2, 1, 4, 5, 1, 1, 3, 1, 1, 7, 7, 7, 5, 5 };
            List<int> randoms4 = new List<int>() { 4, 2, 0, 7, 9, 5, 4, 8, 4, 0, 3, 7, 0, 6, 0, 6, 5, 3, 2, 6, 3, 3, 4, 8, 1 };

            List<List<IGuest>> guestGroups = new List<List<IGuest>>();
            for (int i = 0; i < randoms4.Max()+1; i++)
            {
                guestGroups.Add(new List<IGuest>());
            }
            int j = 0;
            foreach (int i in randoms2)
            {
                IGuest guest = new Guest(randoms1[i], randoms3[j++]);
                guestGroups[randoms4[i]].Add(guest);
            }

            return guestGroups;
         }
    }
}