using NUnit.Framework;

namespace AoC._2016._04
{
    [TestFixture]
    public class Problem04Tests
    {
        private Problem_2016_04 _problem;

        [OneTimeSetUp]
        public void SetUp() => _problem = new Problem_2016_04();

        [TestCase("aaaaa-bbb-z-y-x-123[abxyz]", ExpectedResult = 123)]
        [TestCase("a-b-c-d-e-f-g-h-987[abcde]", ExpectedResult = 987)]
        [TestCase("not-a-real-room-404[oarel]", ExpectedResult = 404)]
        [TestCase("totally-real-room-200[decoy]", ExpectedResult = 0)]
        public int IsARealRoom(string line) => _problem.IsARealRoom(line);

        [TestCase("aaaaa-bbb-z-y-x", ExpectedResult = "abxyz")]
        [TestCase("a-b-c-d-e-f-g-h", ExpectedResult = "abcde")]
        [TestCase("not-a-real-room", ExpectedResult = "oarel")]
        public string CreateCheckSum(string line) => _problem.CreateCheckSum(line);

        [TestCase("fubrjhqlf-edvnhw-dftxlvlwlrq-803[wjvzd]", ExpectedResult = "cryogenic-basket-acquisition")]
        public string Decrypt(string line) => _problem.Decrypt(line);
    }
}