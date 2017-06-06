using System.Collections.Generic;
using NUnit.Framework;

namespace AoC._2015._20
{
    [TestFixture]
    public class Problem20Tests
    {
        private Problem_2015_20 _problem;

        [OneTimeSetUp]
        public void Setup() => _problem = new Problem_2015_20();

        [TestCase(60, ExpectedResult = "1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, 60")]
        [TestCase(72, ExpectedResult = "1, 2, 3, 4, 6, 8, 9, 12, 18, 24, 36, 72")]
        [TestCase(84, ExpectedResult = "1, 2, 3, 4, 6, 7, 12, 14, 21, 28, 42, 84")]
        [TestCase(90, ExpectedResult = "1, 2, 3, 5, 6, 9, 10, 15, 18, 30, 45, 90")]
        [TestCase(96, ExpectedResult = "1, 2, 3, 4, 6, 8, 12, 16, 24, 32, 48, 96")]
        public string GetFactors(int value)
        {
            List<int> factors = _problem.GetElvesThatVisitedHouseNumber(value);
            factors.Sort();
            return string.Join(", ", factors);
        }
    }
}