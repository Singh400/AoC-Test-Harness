using NUnit.Framework;

namespace AoC._2015._03
{
    [TestFixture]
    public sealed class Problem03Tests
    {
        [Test]
        public void SantaStartsAtPositionZero()
        {
            var santa = new Santa();
            var result = santa.Position;
            Assert.That(result, Is.EqualTo("0, 0"));
        }

        [TestCase('<', ExpectedResult = "-1, 0")]
        [TestCase('^', ExpectedResult = "0, 1")]
        [TestCase('>', ExpectedResult = "1, 0")]
        [TestCase('v', ExpectedResult = "0, -1")]
        public string SantaMovesByOneSpace(char input)
        {
            var santa = new Santa();
            santa.Move(input);
            return santa.Position;
        }
    }
}