﻿namespace Homework1
{
    public class DayCalculator
    {
        int currentDayNumber = 5; //Friday
        int currentYear = 2023;
        int currentMonth = 4;
        int currentDay = 28;

        /// <summary>
        /// Given a year, decides whether it's a leapyear or not
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool IsLeapYear(int year)
        {
            //Adjust the method to the following criteria:
            //    Every year that is exactly divisible by four is a leap year, 
            //    except for years that are exactly divisible by 100, 
            //    but these centurial years are leap years if they are exactly divisible by 400.
            //    For example, the years 1700, 1800, and 1900 are not leap years, but the years 1600 and 2000 are.[7]
            //    https://en.wikipedia.org/wiki/Leap_year

            if (year % 400 == 0 )
            {
                return true;

            }
            
            else if(year % 100 == 0)
            {
                return false;
            }

            else if(year % 4 == 0)
            {
                return true; 
            }


            return false;
        }

        /// <summary>
        /// Gives the amount of day in the given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetNumberOfDaysInYear(int year)
        {
            if (IsLeapYear(year) == true)
            {
                return 366;
            }
            return 365;
        }

        /// <summary>
        /// Gives the amount of days in a given month
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public int GetNumberOfDaysInMonth(int month, int year)
        {
            if (month == 2 && IsLeapYear(year) == true)
            {
                return 29;
            }

            else if (month == 2 && IsLeapYear(year) == false)
            {
                return 28;
            }

            else if (month % 2 == 1)
            {
                return 31;
            }

            return 30;
        }

        /// <summary>
        /// Minimalises the amount of days the current day should be adjusted.
        /// Delta 22 would give delta 1. Delta 5 remains delta 5. Delta -11 gives delta -4
        /// </summary>
        /// <param name="delta"></param>
        /// <returns></returns>
        public int GetAdjustedDelta(int delta)
        {

                return delta % 7;

        }

        /// <summary>
        /// Returns the new day of the week, given a current day and the delta.
        /// <param name="dayNumber"></param>
        /// <param name="delta">The number of days the dayNumber needs to be adjusted. Positive for a change in the future, negative for a backwards change</param>
        /// <returns></returns>
        public int GetNewDayOfTheWeek(int dayNumber, int delta)
        {
            int newDelta = GetAdjustedDelta(delta);

            if (dayNumber + newDelta >= 0)
            {
               return (dayNumber + newDelta) % 7;
            }

            return (dayNumber + newDelta) + 7;
        }

        /// <summary>
        /// Returns the day of the week on january 1st 2023.
        /// </summary>
        /// <returns></returns>
        public int DayOfWeekFirstJanuaryCurrentYear()
        {
 
            int totaldays = -1; // Je moet 1 dag minder tellen omdat de huidge dag niet meeteld. Think

            for (int i=1; currentMonth-1 >= i ; i++)
            {
                totaldays = totaldays + GetNumberOfDaysInMonth(i, currentYear);
            }

            totaldays += currentDay;
            int newDay = GetNewDayOfTheWeek(currentDayNumber, (totaldays * -1));

            return newDay;
        }

        public String GetDay(int dayNumber)
        {
            if (dayNumber == 0)
            {
                return "zondag";
            }

            else if (dayNumber == 1)
            {
                return "maandag";
            }

            else if (dayNumber == 2)
            {
                return "dinsdag";
            }

            else if (dayNumber == 3)
            {
                return "woensdag";
            }

            else if (dayNumber == 4)
            {
                return "donderdag";
            }

            else if (dayNumber == 5)
            {
                return "vrijdag";
            }

            else if (dayNumber == 6)
            {
                return "zaterdag";
            }

            return ""; // Ik wil hier eigenlijk een foutmelding geven als er een invalide dag wordt ingevuld maar ik weet niet hoe :)))
        }
    }
}