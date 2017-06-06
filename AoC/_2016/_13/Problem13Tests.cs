using System;
using NUnit.Framework;

namespace AoC._2016._13
{
    [TestFixture]
    public class Problem13Tests
    {
        [Test]
        public void TestThing()
        {
            int answer = SolveForumale(3, 0) + 10;
            string binaryAnswer = Convert.ToString(answer, 2);
            char thing = WallOrOpen(binaryAnswer);
            Assert.That(thing, Is.EqualTo('#'));
        }

        public char WallOrOpen(string input)
        {
            int counter = 0;

            foreach (var letter in input)
            {
                if (letter == '1')
                {
                    counter++;
                }
            }

            return counter%2 == 0 ? '.' : '#';
        }

        public int SolveForumale(int x, int y) => (x*x) + (3*x) + (2*x*y) + y + (y*y);
    }
}