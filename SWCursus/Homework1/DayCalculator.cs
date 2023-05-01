using System;

namespace Homework1
{
    public class DayCalculator
    {
        int currentDayNumber = 5; //Friday
        int currentYear = 2023;
        int currentMonth = 4;
        int currentDay = 28;

        //int currentDayNumber = 3; //woensdag
        //int currentYear = 1986;
        //int currentMonth = 9;
        //int currentDay = 17;
        // 1 jan 1986 was een woensdag --> Deze klopt

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
            if (year % 100 == 0 && year % 400 != 0)
            {
                return false;
            }
            else if (year % 4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            else
            {
                return 365;
            }
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
            else if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                return 31;
            }
            else return 30;
        }

        /// <summary>
        /// BOIJ: Moet de delta zelf niet nog berekend worden?
        /// Gets the delta between currentDate and 1st of January the same year.
        /// </summary>
        public int GetDelta(int year, int month, int day)
        {
            int i = 1;
            int delta = 0;
            while (i < month)
            {
                delta = GetNumberOfDaysInMonth(i, year) + delta;
                i++;
            }
            delta = ((delta - 1) +  day) * (-1);
            return delta;
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
            {
                return (((-1) * delta) % 7) * (-1);
            }
            else
            {
                return delta % 7;
            }
        }

        /// <summary>
        /// Returns the new day of the week, given a current day and the delta.
        /// Deze fout wordt volgens mij al hierboven afgevangen, want er zal nooit '+11' bij komen?
        /// <param name="dayNumber"></param>
        /// <param name="delta">The number of days the dayNumber needs to be adjusted. Positive for a change in the future, negative for a backwards change</param>
        /// <returns></returns>
        public int GetNewDayOfTheWeek(int dayNumber, int delta)
        {
            if (dayNumber + delta < 0)
            {
                return dayNumber + delta + 7;
            }
            else if (dayNumber + delta > 6)
            {
                return dayNumber + delta - 7;
            }
            else
            {
                return dayNumber + delta;
            }
        }

        /// <summary>
        /// Returns the day of the week on january 1st 2023.
        /// </summary>
        /// <returns></returns>
        public int DayOfWeekFirstJanuaryCurrentYear()
        {
            return GetNewDayOfTheWeek(currentDayNumber, GetAdjustedDelta(GetDelta(currentYear, currentMonth, currentDay)));
        }

        public string GetDay(int dayNumber)
        {
            if (DayOfWeekFirstJanuaryCurrentYear() == 0)
            {
                return "zondag";
            }
            if (DayOfWeekFirstJanuaryCurrentYear() == 1)
            {
                return "maandag";
            }
            if (DayOfWeekFirstJanuaryCurrentYear() == 2)
            {
                return "dinsdag";
            }
            if (DayOfWeekFirstJanuaryCurrentYear() == 3)
            {
                return "woensdag";
            }
            if (DayOfWeekFirstJanuaryCurrentYear() == 4)
            {
                return "donderdag";
            }
            if (DayOfWeekFirstJanuaryCurrentYear() == 5)
            {
                return "vrijdag";
            }
            if (DayOfWeekFirstJanuaryCurrentYear() == 6)
            {
                return "zaterdag";
            }
            else
            {
                return "error!";
            }

        }
    }
}