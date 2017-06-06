using NUnit.Framework;

namespace AoC._2015._12
{
    [TestFixture]
    public class Problem12Tests
    {
        [TestCase("{{2,2}]", ExpectedResult = 4)]
        [TestCase("a2,2", ExpectedResult = 4)]
        [TestCase("a22, 1", ExpectedResult = 23)]
        [TestCase("\"a22, 1", ExpectedResult = 23)]
        [TestCase("\"a2:2, 1", ExpectedResult = 23)]
        public int ThatPartOneWorksCorrectly(string input) => Problem_2015_12.PartOne(input);
    }
}