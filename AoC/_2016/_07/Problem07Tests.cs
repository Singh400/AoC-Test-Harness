using NUnit.Framework;

namespace AoC._2016._07
{
    [TestFixture]
    public class Problem07Tests
    {
        private Problem_2016_07 _problem;

        [SetUp]
        public void Setup() => _problem = new Problem_2016_07();

        [TestCase("abba[mnop]qrst", ExpectedResult = true)]
        [TestCase("abcd[bddb]xyyx", ExpectedResult = false)]
        [TestCase("aaaa[qwer]tyui", ExpectedResult = false)]
        [TestCase("ioxxoj[asdfgh]zxcvbn", ExpectedResult = true)]
        public bool SupportTls(string input) => _problem.SupportTls(input);

        [TestCase("aba[bab]xyz", ExpectedResult = true)]
        [TestCase("xyx[xyx]xyx", ExpectedResult = false)]
        [TestCase("aaa[kek]eke", ExpectedResult = true)]
        [TestCase("zazbz[bzb]cdb", ExpectedResult = true)]
        [TestCase("xxnrooghjqtrtkmhr[xhjrmkybtnsrdkp]krhveuyzhsnfrkxq", ExpectedResult = false)]
        [TestCase("txwincbntmaddlmous[qnoqrahfvzcyknc]lyxgbednzodetdivvqa", ExpectedResult = false)]
        [TestCase("uwpvnobjjapdodvuvcn[tcyadiqhfgvyivfrj]gbxojvfhftssxxw", ExpectedResult = false)]
        [TestCase("zlqdqmuxebccmndzbl[ykefimjzdqdmfvlflj]ptlphteflzxmolkof", ExpectedResult = true)]
        public bool SupportsSsl(string input) => _problem.SupportsSsl(input);
    }
}