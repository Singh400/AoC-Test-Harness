using NUnit.Framework;

namespace AoC._2016._01
{
    [TestFixture]
    public class Problem01Tests
    {
        private Ninja _ninja;

        [SetUp]
        public void SetUp()
        {
            _ninja = new Ninja();
        }

        [Test]
        public void One()
        {
            _ninja.Move("R2");
            _ninja.Move("L3");
            int actual = _ninja.LastBlockNumber;
            Assert.That(actual, Is.EqualTo(5));
        }

        [Test]
        public void Two()
        {
            _ninja.Move("R2");
            _ninja.Move("R2");
            _ninja.Move("R2");
            int actual = _ninja.LastBlockNumber;
            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void Three()
        {
            _ninja.Move("R5");
            _ninja.Move("L5");
            _ninja.Move("R5");
            _ninja.Move("R3");
            int actual = _ninja.LastBlockNumber;
            Assert.That(actual, Is.EqualTo(12));
        }

        [Test]
        public void Four()
        {
            _ninja.Move("R8");
            _ninja.Move("R4");
            _ninja.Move("R4");
            _ninja.Move("R8");
            int actual = _ninja.FirstBlockVisitedTwice;
            Assert.That(actual, Is.EqualTo(4));
        }
    }
}