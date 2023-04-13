using Xunit;

namespace Homework1.Tests
{
    public class BirthdayCalculatorTests
    {
        private BirthdayCalculator calculator = new BirthdayCalculator();
        int yearToday = 2023;
        int monthToday = 4;
        int dayToday = 13;

        [Fact]
        public void GetAgeInYears_YearLowerMonthLowerDayLower_CorrectOutput()
        {
            int yearOfBirth = 1960;
            int monthOfBirth = 3;
            int dayOfBirth = 3;

            int output = calculator.GetAgeInYears(yearToday, monthToday, dayToday, yearOfBirth, monthOfBirth, dayOfBirth);

            Assert.Equal(63, output);
        }

        [Fact]
        public void GetAgeInYears_YearLowerMonthLowerDayEqual_CorrectOutput()
        {
            int yearOfBirth = 1972;
            int monthOfBirth = 3;
            int dayOfBirth = 13;

            int output = calculator.GetAgeInYears(yearToday, monthToday, dayToday, yearOfBirth, monthOfBirth, dayOfBirth);

            Assert.Equal(51, output);
        }

        [Fact]
        public void GetAgeInYears_YearLowerMonthLowerDayHigher_CorrectOutput()
        {
            int yearOfBirth = 1972;
            int monthOfBirth = 3;
            int dayOfBirth = 19;

            int output = calculator.GetAgeInYears(yearToday, monthToday, dayToday, yearOfBirth, monthOfBirth, dayOfBirth);

            Assert.Equal(51, output);
        }

        [Fact]
        public void GetAgeInYears_YearInPastMonthInPastDayInPast_CorrectOutput()
        {
            int yearOfBirth = 1960;
            int monthOfBirth = 3;
            int dayOfBirth = 3;

            int output = calculator.GetAgeInYears(yearToday, monthToday, dayToday, yearOfBirth, monthOfBirth, dayOfBirth);

            Assert.Equal(63, output);
        }

        [Fact]
        public void GetAgeInYears_YearInPastMonthInPastDayToday_CorrectOutput()
        {
            int yearOfBirth = 1972;
            int monthOfBirth = 3;
            int dayOfBirth = 13;

            int output = calculator.GetAgeInYears(yearToday, monthToday, dayToday, yearOfBirth, monthOfBirth, dayOfBirth);

            Assert.Equal(51, output);
        }

        [Fact]
        public void GetAgeInYears_YearInPastMonthInPastDayinFuture_CorrectOutput()
        {
            int yearOfBirth = 1972;
            int monthOfBirth = 3;
            int dayOfBirth = 19;

            int output = calculator.GetAgeInYears(yearToday, monthToday, dayToday, yearOfBirth, monthOfBirth, dayOfBirth);

            Assert.Equal(51, output);
        }
    }
}
