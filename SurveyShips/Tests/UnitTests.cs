using System;
using Xunit;
using SurveyShips;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void TestNullInput()
        {
            string[] input = null;
            Assert.Throws<ArgumentException>(() => InputHandler.ProcessInput(input));
        }

        [Fact]
        public void TestEvenInput()
        {
            string[] input = new string[]
            {
                "5 3",
                "1 1 E",
                "RFRFRFRF",
                "",
                "3 2 N"
            };

            Assert.Throws<ArgumentException>(() => InputHandler.ProcessInput(input));
        }

        [Fact]
        public void TestGivenExample()
        {
            string[] input = new string[]
            {
                "5 3",
                "1 1 E",
                "RFRFRFRF",
                "",
                "3 2 N",
                "FRRFLLFFRRFLL",
                "",
                "0 3 W",
                "LLFFFLFLFL"
            };

            string[] expectedOutput = new string[]
            {
                "1 1 E",
                "3 3 N LOST",
                "2 3 S"
            };

            string[] output = InputHandler.ProcessInput(input);
            Assert.Equal(expectedOutput, output);
        }
    }
}
