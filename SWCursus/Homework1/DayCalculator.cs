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
            if (year % 4 != 0) // niet deelbaar door 4, sowieso geen leap year
                return false;
            else if (year % 100 != 0) // alles deelbaar door 4, checken of deelbaar door 100. Zo niet, dan sowieso leap year 
                return true;
            else if (year % 400 == 0) // alles deelbaar door 4 en deelbaar door 100, checken of deelbaar door 400. Zo ja, leap year; zo niet, geen leap year.
                return true; 
            else 
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
                return 366;
            else return 365;
        }

        /// <summary>
        /// Gives the amount of days in a given month
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public int GetNumberOfDaysInMonth(int month, int year)
        {
            switch (month)
            {
                case 1:
                    return 31;
                case 2:
                    if (IsLeapYear(year) == true)
                        return 29; 
                    else return 28;
                case 3:
                    return 31;
                case 4: 
                    return 30; 
                case 5: 
                    return 31; 
                case 6: 
                    return 30; 
                case 7: 
                    return 31; 
                case 8: 
                    return 31;
                case 9: 
                    return 30; 
                case 10: 
                    return 31;
                case 11: 
                    return 30;
                case 12: 
                    return 31;
                default: 
                    return 0; 
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
            int adjustedDelta = delta % 7; 
            return adjustedDelta;
        }

        /// <summary>
        /// Returns the new day of the week, given a current day and the delta.
        /// <param name="dayNumber"></param>
        /// <param name="delta">The number of days the dayNumber needs to be adjusted. Positive for a change in the future, negative for a backwards change</param>
        /// <returns></returns>
        public int GetNewDayOfTheWeek(int dayNumber, int delta)
        {
            int newDayOfTheWeek;
            int adjustedDelta = GetAdjustedDelta(delta);

            newDayOfTheWeek = (dayNumber + adjustedDelta + 7) % 7;
            
            return newDayOfTheWeek;
        }

        /// <summary>
        /// Returns the day of the week on january 1st 2023.
        /// </summary>
        /// <returns></returns>
        public int DayOfWeekFirstJanuaryCurrentYear()
        {

            int day = 1;
            int month = 1;
            //int year = 2023; 
            int dateDifference = 0;

            int monthOmAfTeTellen = currentMonth; // vanaf deze stapsgewijs gaan aftellen en daarmee datedifference optellen, totdat monthomaftetellen gelijk is aan month 
            //int yearOmAfTeTellen = currentYear; 

            //eerst naar hetzelfde dagnummer terugtellen deel van de maand) 
            if (currentDay >= day) // bvb in geval van de opdracht: 28-4 > 1-4. Datediff = 27
            {
                dateDifference = -(currentDay - day);
            } // --> de dagen van april zijn nu opgeteld (eigenlijk afgeteld); datedifference = 27; monthOmAfTeTellen = 4
            
            // Ook alvast onderstaande ingebouwd om voor andere voorgaande dagen in hetzelfde jaar te kunnen bepalen:
            else // bvb stel dat we het niet voor 1-1 willen weten, maar voor 30-1: 28-4 > 30-3. Datediff = -(28+aantaldageninmaandervoor -30) = -(59-30)= -29 dagen
            {
                dateDifference = -(currentDay + GetNumberOfDaysInMonth(monthOmAfTeTellen - 1, currentYear) - day);
                monthOmAfTeTellen = monthOmAfTeTellen - 1;
            } // de dagen van mei zijn opgeteld; datedifference = 4; monthOmAfTeTellen = 4
            

            // in beide gevallen verder met het bijtellen (of aftellen eigenlijk) van de dagen van maart -> + 31 dagen en monthOmAfTeTellen = 3
            // vervolgens aftellen van dagen van februari -> + 28 dagen voor 2023 en monthOmAfTeTellen = 2
            // ook aftellen van dagen van januari -> + 31 en stoppen, want de datum die we willen weten is in januari (month = 1); monthOmAfTeTellen = 1  

            while (monthOmAfTeTellen > month)
            {
                dateDifference = dateDifference - GetNumberOfDaysInMonth(monthOmAfTeTellen - 1, currentYear);
                monthOmAfTeTellen = monthOmAfTeTellen - 1;
            }

            //datediff moet zijn 117
            //return DateDifference

            //int AdjustedDelta = GetAdjustedDelta(DateDifference);
            //return AdjustedDelta;

            int dayOfWeek = GetNewDayOfTheWeek(currentDayNumber, dateDifference);
            return dayOfWeek;

        }

        public string GetDay(int dayNumber)
        {
            switch (dayNumber)
            {
                case 0:
                    return "Sunday";
                case 1:
                    return "Monday";
                case 2:
                    return "Tuesday";
                case 3:
                    return "Wednesday";
                case 4:
                    return "Thursday";
                case 5:
                    return "Friday";
                case 6:
                    return "Saturday";
                default:
                    return "unknown";
            } 
        }
    }
}