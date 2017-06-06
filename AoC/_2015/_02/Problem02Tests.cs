using NUnit.Framework;

namespace AoC._2015._02
{
    [TestFixture]
    public sealed class Problem02Tests
    {
        [TestCase("2x3x4", ExpectedResult = 58)]
        [TestCase("1x1x10", ExpectedResult = 43)]
        public int ThenTheSurfaceAreaIsCorrect(string input) => new Dimension(input).SurfaceArea();

        [TestCase("2x3x4", ExpectedResult = 34)]
        [TestCase("1x1x10", ExpectedResult = 14)]
        public int ThenTheRibbonNeededIsCorrect(string input) => new Dimension(input).RibbonNeeded();
    }
}
