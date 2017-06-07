using NUnit.Framework;

namespace AoC._2016._06
{
    [TestFixture]
    public class Problem06Tests
    {
        private Problem_2016_06 _problem;

        private readonly string[] lines =
        {
            "eedadn",
            "drvtee",
            "eandsr",
            "raavrd",
            "atevrs",
            "tsrnev",
            "sdttsa",
            "rasrtv",
            "nssdts",
            "ntnada",
            "svetve",
            "tesnvt",
            "vntsnd",
            "vrdear",
            "dvrsen",
            "enarar"
        };

        [SetUp]
        public void Setup() => _problem = new Problem_2016_06();

        [Test]
        public void RecoverByMostCommon()
        {
            string result = _problem.Recover(lines, new FindMostCommonLetter());
            Assert.That(result, Is.EqualTo("easter"));
        }

        [Test]
        public void RecoverByLeastCommon()
        {
            string result = _problem.Recover(lines, new FindLeastCommonLetter());
            Assert.That(result, Is.EqualTo("advent"));
        }
    }
}