using NUnit.Framework;

namespace AoC._2015._05
{
    [TestFixture]
    public sealed class Problem05Tests
    {
        private Problem_2015_05 _problem;

        [OneTimeSetUp]
        public void Setup() => _problem = new Problem_2015_05();

        [TestCase("ugknbfddgicrmopn", ExpectedResult = true)]
        [TestCase("aeiouaeiouaeiou", ExpectedResult = true)]
        [TestCase("aei", ExpectedResult = true)]
        [TestCase("aaa", ExpectedResult = true)]
        [TestCase("xazegov", ExpectedResult = true)]
        [TestCase("dvszwmarrgswjxmb", ExpectedResult = false)]
        public bool HasAtLeastThreeVowels(string input) => _problem.HasAtLeastThreeVowels(input);

        [TestCase("ugknbfddgicrmopn", ExpectedResult = true)]
        [TestCase("jchzalrnumimnmhp", ExpectedResult = false)]
        public bool HasAPairOfLetters(string input) => _problem.HasAPairOfLetters(input);

        [TestCase("ugknbfddgicrmopn", ExpectedResult = false)]
        [TestCase("haegwjzuvuyypxyu", ExpectedResult = true)]
        public bool HasBadStrings(string input) => _problem.HasBadStrings(input);

        [TestCase("ugknbfddgicrmopn", ExpectedResult = true)]
        [TestCase("aaa", ExpectedResult = true)]
        [TestCase("jchzalrnumimnmhp", ExpectedResult = false)]
        [TestCase("haegwjzuvuyypxyu", ExpectedResult = false)]
        [TestCase("dvszwmarrgswjxmb", ExpectedResult = false)]
        public bool IsANiceStringPartOne(string input) => _problem.IsANiceStringPartOne(input);

        [TestCase("aaaa", ExpectedResult = true)]
        [TestCase("qjhvhtzxzqqjkmpb", ExpectedResult = true)]
        [TestCase("qjhvhtxxyxxzxzqqjkmpb", ExpectedResult = true)]
        [TestCase("aaa", ExpectedResult = false)]
        [TestCase("uurcxstgmygtbstg", ExpectedResult = true)]
        public bool HasDuplicatePairOfLetters(string input) => _problem.HasDuplicatePairOfLetters(input);

        [TestCase("aaaa", ExpectedResult = true)]
        [TestCase("abcdefeghi", ExpectedResult = true)]
        [TestCase("qjhvhtzxzqqjkmpb", ExpectedResult = true)]
        [TestCase("xxyxx", ExpectedResult = true)]
        [TestCase("ieodomkazucvgmuy", ExpectedResult = true)]
        [TestCase("uurcxstgmygtbstg", ExpectedResult = false)]
        public bool HasAPairOfLettersWithALetterBetween(string input) => _problem.HasAPairOfLettersWithALetterBetween(input);

        [TestCase("qjhvhtzxzqqjkmpb", ExpectedResult = true)]
        [TestCase("xxyxx", ExpectedResult = true)]
        public bool IsANiceStringPartTwo(string input) => _problem.IsANiceStringPartTwo(input);
    }
}