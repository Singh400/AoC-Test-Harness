using NUnit.Framework;

namespace AoC._2016._02
{
    [TestFixture]
    public class Problem02Tests
    {
        [TestCase("U", ExpectedResult = "2")]
        [TestCase("UU", ExpectedResult = "2")]
        [TestCase("UUU", ExpectedResult = "2")]

        [TestCase("R", ExpectedResult = "6")]
        [TestCase("RR", ExpectedResult = "6")]
        [TestCase("RRR", ExpectedResult = "6")]
        
        [TestCase("D", ExpectedResult = "8")]
        [TestCase("DD", ExpectedResult = "8")]
        [TestCase("DDD", ExpectedResult = "8")]

        [TestCase("L", ExpectedResult = "4")]
        [TestCase("LL", ExpectedResult = "4")]
        [TestCase("LLL", ExpectedResult = "4")]

        [TestCase("", ExpectedResult = "5")]
        public string SimpleNumberPadTest(string line)
        {
            var ninja = new Ninja(new SimpleNumberPad());
            ninja.Process(line);
            return ninja.EntryKey;
        }

        [TestCase("", ExpectedResult = "5")]
        [TestCase("R", ExpectedResult = "6")]
        [TestCase("RR", ExpectedResult = "7")]
        [TestCase("RRR", ExpectedResult = "8")]
        [TestCase("RRRR", ExpectedResult = "9")]
        [TestCase("RRRRR", ExpectedResult = "9")]

        [TestCase("U", ExpectedResult = "5")]
        [TestCase("UU", ExpectedResult = "5")]
        [TestCase("UUUU", ExpectedResult = "5")]
        [TestCase("UUUUU", ExpectedResult = "5")]
        [TestCase("UUUUUU", ExpectedResult = "5")]

        [TestCase("D", ExpectedResult = "5")]
        [TestCase("DD", ExpectedResult = "5")]
        [TestCase("DDDD", ExpectedResult = "5")]
        [TestCase("DDDDD", ExpectedResult = "5")]
        [TestCase("DDDDDD", ExpectedResult = "5")]

        [TestCase("L", ExpectedResult = "5")]
        [TestCase("LL", ExpectedResult = "5")]
        [TestCase("LLLL", ExpectedResult = "5")]
        [TestCase("LLLLL", ExpectedResult = "5")]
        [TestCase("LLLLLL", ExpectedResult = "5")]

        [TestCase("RD", ExpectedResult = "A")]
        [TestCase("RU", ExpectedResult = "2")]
        [TestCase("RUU", ExpectedResult = "2")]
        public string ComplexNumberPadTests(string line)
        {
            var ninja = new Ninja(new ComplexNumberPad());
            ninja.Process(line);
            return ninja.EntryKey;
        }
    }
}