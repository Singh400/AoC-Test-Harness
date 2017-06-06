using NUnit.Framework;

namespace AoC._2015._10
{
    [TestFixture]
    public class Problem10Tests
    {
        [TestCase("0", ExpectedResult = "10")]
        [TestCase("1", ExpectedResult = "11")]
        [TestCase("11", ExpectedResult = "21")]
        [TestCase("21", ExpectedResult = "1211")]
        [TestCase("1211", ExpectedResult = "111221")]
        [TestCase("111221", ExpectedResult = "312211")]
        [TestCase("1113222113", ExpectedResult = "3113322113")]
        public string ThatLookAndSayWorksCorrectly(string input) => Problem_2015_10.LookAndSay(input);
    }
}