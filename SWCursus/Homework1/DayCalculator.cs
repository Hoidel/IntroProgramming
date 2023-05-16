using System.Reflection;

namespace Homework1
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
            //return year % 100 == 0 ? year % 400 == 0 : year % 4 == 0; korte variant

            if (year % 400 == 0)
            {
                return true;
            }


            if (year % 100 == 0)
            {
                return false;
            }

          
            //Adjust the method to the following criteria:
            //    Every year that is exactly divisible by four is a leap year, 
            //    except for years that are exactly divisible by 100, 
            //    but these centurial years are leap years if they are exactly divisible by 400.
            //    For example, the years 1700, 1800, and 1900 are not leap years, but the years 1600 and 2000 are.[7]
            //    https://en.wikipedia.org/wiki/Leap_year
            return (year % 4 == 0);
        }

        /// <summary>
        /// Gives the amount of day in the given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetNumberOfDaysInYear(int year)
        {
            if (IsLeapYear(year))
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
            switch(month)
            {
                case 1 or 3 or 5 or 7 or 8 or 10 or 12:
                    return 31;
                case 2:
                    if (IsLeapYear(year))
                    { return 29; }
                    else
                    { return 28; }
                //case 4 or 6 or 9 or 11:
                //    return 30;



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
            if (delta < 0)
            { return (Math.Abs(delta) % 7) * -1; }
            return delta % 7;
        }

        /// <summary>
        /// Returns the new day of the week, given a current day and the delta.
        /// <param name="dayNumber"></param>
        /// <param name="delta">The number of days the dayNumber needs to be adjusted. Positive for a change in the future, negative for a backwards change</param>
        /// <returns></returns>
        public int GetNewDayOfTheWeek(int dayNumber, int delta)
        {
            int newdelta = GetAdjustedDelta(delta);
            int newday = dayNumber + newdelta;
            return newday % 7;
        }

        /// <summary>
        /// Returns the day of the week on january 1st 2023.
        /// </summary>
        /// <returns></returns>
        public int DayOfWeekFirstJanuaryCurrentYear()
        {
            
            int days = 0;
           
                        
            // number of days up to currentmonth
            for (int i = 1; i < (currentMonth); i++)
                
                days += GetNumberOfDaysInMonth(i, currentYear);
            // days in currenmonth - minus 1 
            days += (currentDay - 1); 
            
            int daynumber = GetNewDayOfTheWeek(currentDayNumber, -days);



            return daynumber;
        }



        public string GetDay(int dayNumber)
        {   switch (dayNumber)
            {case 0: return "zondag";
                case 1: return "maandag";
                case 2: return "dinsdag";
                case 3: return "woensdag";
                case 4: return "donderdag";
                case 5: return "vrijdag";
                case 6: return "zaterdag";





            }


            return "geen dag van de week";
        }
    }
}