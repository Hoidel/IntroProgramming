namespace Day1.Tests
{
    public class StringManipulatorTests
    {
        private StringManipulator manipulator = new StringManipulator();

        [Fact]
        public void Reverse_RandomText_CorrectOutput()
        {
            string input = "sadsdasd";

            string output = manipulator.Reverse(input);

            Assert.Equal("dsadsdas", output);
        }

        [Fact]
        public void Reverse_EmptyString_EmptyString()
        {
            string input = "";

            string output = manipulator.Reverse(input);

            Assert.Equal("", output);
        }

        [Fact]
        public void Reverse_NullString_EmptyString()
        {
            string? input = null;

            string output = manipulator.Reverse(input);

            Assert.Equal("", output);
        }
    }
}