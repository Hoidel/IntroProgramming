using Xunit;

namespace Homework1.Tests
{
    public class BirthdayCalculatorTests
    {
        private DayCalculator calculator = new DayCalculator();
        
        [Fact]
        public void DayOfWeekFirstJanuaryCurrentYear_2023_CorrectOutput()
        {
            int output = calculator.DayOfWeekFirstJanuaryCurrentYear();

            Assert.Equal(0, output); // january 1st 2023 was a sunday;
        }

        [Fact]
        public void GetNewDayOfTheWeek_5plus11_CorrectOutput()
        {
            int output = calculator.GetNewDayOfTheWeek(5, 11);

            Assert.Equal(2, output); // friday + 11 = tuesday
        }

        [Fact]
        public void GetNewDayOfTheWeek_2plus3_CorrectOutput()
        {
            int output = calculator.GetNewDayOfTheWeek(2, 3);

            Assert.Equal(5, output); // tuesday + 3 = friday
        }

        [Fact]
        public void GetNewDayOfTheWeek_0plus7_CorrectOutput()
        {
            int output = calculator.GetNewDayOfTheWeek(0, 7);

            Assert.Equal(0, output); // sunday + 7 = sunday
        }

        [Fact]
        public void GetNewDayOfTheWeek_5minus11_CorrectOutput()
        {
            int output = calculator.GetNewDayOfTheWeek(5, -11);

            Assert.Equal(1, output); // friday - 11 = monday
        }

        [Fact]
        public void GetNewDayOfTheWeek_6minus3_CorrectOutput()
        {
            int output = calculator.GetNewDayOfTheWeek(6, -3);

            Assert.Equal(3, output); // saturday - 3 = wednesday
        }

        [Fact]
        public void GetNewDayOfTheWeek_0minus7_CorrectOutput()
        {
            int output = calculator.GetNewDayOfTheWeek(0, -7);

            Assert.Equal(0, output); // sunday - 7 = sunday
        }

        [Fact]
        public void IsLeapYear_1987_CorrectOutput()
        {
            bool output = calculator.IsLeapYear(1987);

            Assert.False(output);
        }

        [Fact]
        public void IsLeapYear_204_CorrectOutput()
        {
            bool output = calculator.IsLeapYear(204);

            Assert.True(output);
        }

        [Fact]
        public void IsLeapYear_1900_CorrectOutput()
        {
            bool output = calculator.IsLeapYear(1900);

            Assert.False(output);
        }

        [Fact]
        public void IsLeapYear_4000_CorrectOutput()
        {
            bool output = calculator.IsLeapYear(4000);

            Assert.True(output);
        }

        [Fact]
        public void GetNumberOfDaysInYear_4000_CorrectOutput()
        {
            int output = calculator.GetNumberOfDaysInYear(4000);

            Assert.Equal(366, output);
        }

        [Fact]
        public void GetNumberOfDaysInYear_2023_CorrectOutput()
        {
            int output = calculator.GetNumberOfDaysInYear(2023);

            Assert.Equal(365, output);
        }

        [Fact]
        public void GetNumberOfDaysInMonth_February1996_CorrectOutput()
        {
            int output = calculator.GetNumberOfDaysInMonth(2, 1996);

            Assert.Equal(29, output);
        }

        [Fact]
        public void GetNumberOfDaysInMonth_February1997_CorrectOutput()
        {
            int output = calculator.GetNumberOfDaysInMonth(2, 1997);

            Assert.Equal(28, output);
        }

        [Fact]
        public void GetNumberOfDaysInMonth_March2023_CorrectOutput()
        {
            int output = calculator.GetNumberOfDaysInMonth(3, 2023);

            Assert.Equal(31, output);
        }

        [Fact]
        public void GetAdjustedDelta_23_2()
        {
            int output = calculator.GetAdjustedDelta(23);

            Assert.Equal(2, output);
        }

        [Fact]
        public void GetAdjustedDelta_4_4()
        {
            int output = calculator.GetAdjustedDelta(4);

            Assert.Equal(4, output);
        }

        [Fact]
        public void GetAdjustedDelta_m1_m1()
        {
            int output = calculator.GetAdjustedDelta(-1);

            Assert.Equal(-1, output);
        }

        [Fact]
        public void GetAdjustedDelta_m23_m2()
        {
            int output = calculator.GetAdjustedDelta(-23);

            Assert.Equal(-2, output);
        }
    }
}
