using System;

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
            //Adjust the method to the following criteria:
            //    Every year that is exactly divisible by four is a leap year, 
            //    except for years that are exactly divisible by 100, 
            //    but these centurial years are leap years if they are exactly divisible by 400.
            //    For example, the years 1700, 1800, and 1900 are not leap years, but the years 1600 and 2000 are.[7]
            //    https://en.wikipedia.org/wiki/Leap_year
            if (year % 400 == 0)
            { return true; }
            else if (year % 100 == 0)
            { return false; }
            else if (year % 4 == 0)
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// Gives the amount of day in the given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetNumberOfDaysInYear(int year)
        {
            int NumberOfDaysInYear;
            if (IsLeapYear(year) == true)
                {
                NumberOfDaysInYear = 366;
                }
            else
                {
                NumberOfDaysInYear = 365;
                }
            return NumberOfDaysInYear;
        }

        /// <summary>
        /// Gives the amount of days in a given month
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public int GetNumberOfDaysInMonth(int month, int year)
        {
            int NrOfDaysInMonth;
            switch (month)
                { 
                case 1:
                    NrOfDaysInMonth = 31; 
                    break;
                case 2:
                    if (IsLeapYear(year) == true)
                    {
                        NrOfDaysInMonth = 29;
                        break;
                    }
                    else
                    {
                        NrOfDaysInMonth = 28;
                        break;
                    }
                case 3:
                    NrOfDaysInMonth = 31; 
                    break;
                case 4:
                    NrOfDaysInMonth = 30; 
                    break;
                case 5:
                    NrOfDaysInMonth = 31; 
                    break;
                case 6:
                    NrOfDaysInMonth = 30; 
                    break;
                case 7:
                    NrOfDaysInMonth = 31; 
                    break;
                case 8:
                    NrOfDaysInMonth = 31; 
                    break;
                case 9:
                    NrOfDaysInMonth = 30; 
                    break;
                case 10:
                    NrOfDaysInMonth = 31; 
                    break;
                case 11:
                    NrOfDaysInMonth = 30; 
                    break;
                case 12:
                    NrOfDaysInMonth = 31;
                    break;
                default: NrOfDaysInMonth = 99;
                    break;
            }
            return NrOfDaysInMonth;
        }

        /// <summary>
        /// Minimalises the amount of days the current day should be adjusted.
        /// Delta 22 would give delta 1. Delta 5 remains delta 5. Delta -11 gives delta -4
        /// </summary>
        /// <param name="delta"></param>
        /// <returns></returns>
        public int GetAdjustedDelta(int delta)
        {
            int AdjustedDelta;
            if (delta >= 0)
                {
                AdjustedDelta = delta % 7;
                }
            else
                {
                AdjustedDelta = delta % -7;
                }
            
            return AdjustedDelta;
        }

        /// <summary>
        /// Returns the new day of the week, given a current day and the delta.
        /// <param name="dayNumber"></param>
        /// <param name="delta">The number of days the dayNumber needs to be adjusted. Positive for a change in the future, negative for a backwards change</param>
        /// <returns></returns>
        public int GetNewDayOfTheWeek(int dayNumber, int delta)
        {
            int NewDayOfTheWeek = (dayNumber + GetAdjustedDelta(delta)) % 7;
            return NewDayOfTheWeek;
        }

        /// <summary>
        /// Returns the day of the week on january 1st 2023.
        /// </summary>
        /// <returns></returns>
        public int DayOfWeekFirstJanuaryCurrentYear()
        {
            int FirstJanuaryYear = 2023;
            int FirstJanuaryMonth = 1;
            int FirstJanuaryDay = 1;
            int DeltaDays = 0;

            if (currentYear > FirstJanuaryYear)
            {
                for (int GoalYear = FirstJanuaryYear; currentYear > GoalYear; currentYear--)
                {
                    DeltaDays = DeltaDays - GetNumberOfDaysInYear(currentYear);
                }
            }
            else if (currentYear < FirstJanuaryYear)
            {
                for (int GoalYear = FirstJanuaryYear; currentYear < GoalYear; currentYear++)
                {
                    DeltaDays = DeltaDays + GetNumberOfDaysInYear(currentYear);
                }
            }
            else if (currentMonth > FirstJanuaryMonth)
            {
                for (int GoalMonth = FirstJanuaryMonth; currentMonth > GoalMonth; currentMonth--)
                {
                    DeltaDays = DeltaDays - GetNumberOfDaysInMonth(currentMonth,currentYear);
                }
            }
            else if (currentMonth < FirstJanuaryMonth)
            {
                for (int GoalMonth = FirstJanuaryMonth; currentMonth < GoalMonth; currentMonth++)
                {
                    DeltaDays = DeltaDays + GetNumberOfDaysInMonth(currentMonth, currentYear);
                }
            }
            else if (currentDay > FirstJanuaryDay)
            {
                for (int GoalDay = FirstJanuaryDay; currentDay > GoalDay; currentDay--)
                {
                    DeltaDays = DeltaDays--;
                }
            }
            else if (currentDay < FirstJanuaryDay)
            {
                for (int GoalDay = FirstJanuaryDay; currentDay < GoalDay; currentDay++)
                {
                    DeltaDays = DeltaDays++;
                }
            }
            return GetNewDayOfTheWeek(currentDayNumber,DeltaDays) ;
        }

        public string GetDay(int dayNumber)
        {
            string DayName;
            switch (dayNumber)
            {
                case 0:
                    DayName = "zondag";
                    break;
                case 1:
                    DayName = "maandag";
                    break;
                case 2:
                    DayName = "dinsdag";
                    break;
                case 3:
                    DayName = "woensdag";
                    break;
                case 4:
                    DayName = "donderdag";
                    break;
                case 5:
                    DayName = "vrijdag";
                    break;
                case 6:
                    DayName = "zaterdag";
                    break;
                default: DayName = "onbekend";
                    break;
            }
            return DayName;
        }
    }
}