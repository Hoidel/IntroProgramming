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
            if (year % 400 == 0)
            { 
                return true;
            }
            else if (year % 100 == 0)
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
            //Adjust the method to the following criteria:
            //    Every year that is exactly divisible by four is a leap year, 
            //    except for years that are exactly divisible by 100, 
            //    but these centurial years are leap years if they are exactly divisible by 400.
            //    For example, the years 1700, 1800, and 1900 are not leap years, but the years 1600 and 2000 are.[7]
            //    https://en.wikipedia.org/wiki/Leap_year
        }

        /// <summary>
        /// Gives the amount of day in the given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetNumberOfDaysInYear(int year)
        {
            if (!IsLeapYear(year) == true)
            {
                return 365;
            }
            else
            {
                return 366;
            }
        }

        /// <summary>
        /// Gives the amount of days in a given month
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public int GetNumberOfDaysInMonth(int month, int year)
        {
            if (GetNumberOfDaysInYear(year) == 366 && month == 2)
            {
                return 29;
            }
            else if (GetNumberOfDaysInYear(year) == 365 && month == 2)
            {
                return 28;
            }
            else if (month == 1)
            {
                return 31;
            }
            else if (month == 3)
            {
                return 31;
            }
            else if (month == 4)
            {
                return 30;
            }
            else if (month == 5)
            {
                return 31;
            }
            else if (month == 6)
            {
                return 30;
            }
            else if (month == 7)
            {
                return 31;
            }
            else if (month == 8)
            {
                return 31;
            }
            else if (month == 9)
            {
                return 30;
            }
            else if (month == 10)
            {
                return 31;
            }
            else if (month == 11)
            {
                return 30;
            }
            else
            {
                return 31;
            }

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
            return (GetAdjustedDelta(delta) + dayNumber % 7) % 7;
        }

        /// <summary>
        /// Returns the day of the week on january 1st 2023.
        /// </summary>
        /// <returns></returns>
        public int DayOfWeekFirstJanuaryCurrentYear()
        {
            return 9000;
        }

        public string GetDay(int dayNumber)
        {
            switch (dayNumber)
            {
                case 0:
                    return"zondag";
                case 1:
                    return"maandag";
                case 2:
                    return"dinsdag";
                case 3:
                    return"woensdag";
                case 4:
                    return"donderdag";
                case 5:
                    return"vrijdag";
                case 6:
                    return"zaterdag";
                default:
                    return"onbekende dag";
            }
        }
    }
}