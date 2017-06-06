using NUnit.Framework;

namespace AoC._2015._11
{
    [TestFixture]
    public class Problem11Tests
    {
        private Problem_2015_11 _problem;

        [OneTimeSetUp]
        public void Setup() => _problem = new Problem_2015_11();

        [TestCase("hijklmmn", ExpectedResult = true)]
        [TestCase("abbceffg", ExpectedResult = false)]
        [TestCase("cqkaabcc", ExpectedResult = true)]
        public bool HasThreeLetterInARow(string value) => _problem.HasThreeLetterInARow(value);

        [TestCase("hijklmmn", ExpectedResult = true)]
        [TestCase("abbceffg", ExpectedResult = false)]
        [TestCase("cqkaabcc", ExpectedResult = false)]
        public bool HasIllegalLetters(string value) => _problem.HasIllegalLetters(value);

        [TestCase("hijklmmn", ExpectedResult = false)]
        [TestCase("abbceffg", ExpectedResult = true)]
        [TestCase("abbcegjk", ExpectedResult = false)]
        [TestCase("cqkaabcc", ExpectedResult = true)]
        public bool HasPairs(string value) => _problem.HasPairs(value);

        [TestCase("abcdefgh", ExpectedResult = "abcdffaa")]
        [TestCase("ghijklmn", ExpectedResult = "ghjaabcc")]
        public string GetNextPassword(string value) => _problem.GetNextPassword(value);

        [TestCase("xx", ExpectedResult = "xy")]
        [TestCase("xy", ExpectedResult = "xz")]
        [TestCase("xz", ExpectedResult = "ya")]
        [TestCase("ya", ExpectedResult = "yb")]
        [TestCase("yb", ExpectedResult = "yc")]
        [TestCase("aaa", ExpectedResult = "aab")]
        [TestCase("abcdefgh", ExpectedResult = "abcdefgi")]
        public string Increment(string value) => _problem.Increment(value);
    }
}