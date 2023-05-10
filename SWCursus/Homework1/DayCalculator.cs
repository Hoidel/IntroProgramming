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
            bool isLeapYear = false;
           if ((year % 400) == 0)
            {
                isLeapYear = true;
            }

            else if ((year % 100) == 0)
            {
                isLeapYear = false;
            }
            else if ((year % 4) == 0)
                    {
                        isLeapYear = true;
                    }

            return isLeapYear;
        }

        /// <summary>
        /// Gives the amount of day in the given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetNumberOfDaysInYear(int year)
        {
            int NumberOfDays = 0;
            if (IsLeapYear(year) == true) { 
            NumberOfDays= 366;
            }
            else if (IsLeapYear(year) == false)
            {
                NumberOfDays= 365;
            }
           
            return NumberOfDays;
        }

        /// <summary>
        /// Gives the amount of days in a given month
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public int GetNumberOfDaysInMonth(int month, int year)
        {
            int NumberOfDaysInMonth = 0;
            if (month == 1||
                month == 3 ||
                month == 5 ||
                month == 7 ||
                month == 8 ||
                month == 10 ||
                month == 12 ) 
            {
                NumberOfDaysInMonth = 31;
            }
            else if (month == 2 && 
                IsLeapYear(year) == true
                )
            { 
                NumberOfDaysInMonth = 29;
            }
            else if (month == 2)
            {
                NumberOfDaysInMonth = 28;
            }
            else
            {
                NumberOfDaysInMonth = 30;
            }
            return NumberOfDaysInMonth;
        }

        /// <summary>
        /// Minimalises the amount of days the current day should be adjusted.
        /// Delta 22 would give delta 1. Delta 5 remains delta 5. Delta -11 gives delta -4
        /// </summary>
        /// <param name="delta"></param>
        /// <returns></returns>
        public int GetAdjustedDelta(int delta)
        {
            if (delta <= 7 &&
                delta >= -7)
            {
                delta = delta + 0;
            }
            else if (delta < 0)
            {
                delta = delta % -7;
            }
            else delta = delta % 7;
            return delta;
        }

        /// <summary>
        /// Returns the new day of the week, given a current day and the delta.
        /// <param name="dayNumber"></param>
        /// <param name="delta">The number of days the dayNumber needs to be adjusted. Positive for a change in the future, negative for a backwards change</param>
        /// <returns></returns>
        public int GetNewDayOfTheWeek(int dayNumber, int delta)
        {
            int NewDayOfTheWeekNumber = dayNumber + GetAdjustedDelta(delta);
            if (NewDayOfTheWeekNumber <= 6 &&
               NewDayOfTheWeekNumber >= 0)
            {
                NewDayOfTheWeekNumber = NewDayOfTheWeekNumber+0;
            }
            else if (NewDayOfTheWeekNumber < 0 &&
                NewDayOfTheWeekNumber >= -6)
            {
                NewDayOfTheWeekNumber = 6 - NewDayOfTheWeekNumber;
            }

            else if (NewDayOfTheWeekNumber < 0)
            {
                NewDayOfTheWeekNumber = NewDayOfTheWeekNumber % -7;
            }
            else NewDayOfTheWeekNumber = NewDayOfTheWeekNumber % 7;
            return NewDayOfTheWeekNumber;
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
            string dayName = "";
            switch (dayNumber)
            {
                case 0: dayName = "zondag";
                    break;
                case 1: dayName = "maandag";
                    break;
                case 2: dayName = "dinsdag";
                    break;
                case 3: dayName = "woensdag";
                    break;
                case 4: dayName = "donderdag";
                    break;
                case 5: dayName = "vrijdag";
                    break;
                case 6: dayName = "zaterdag";
                    break;
                default: dayName = "ongeldige waarde";
                    break;
            }
                    
            return dayName;
        }
    }
}