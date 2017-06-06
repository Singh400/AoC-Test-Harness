using NUnit.Framework;

namespace AoC._2016._12
{
    [TestFixture]
    public class Problem12Tests
    {
        [Test]
        public void PartOne()
        {
            Problem_2016_12 problem = new Problem_2016_12();


            string[] lines = new[]
            {
                "cpy 41 a",
                "inc a",
                "inc a",
                "dec a",
                "jnz a 2",
                "dec a"
            };

            problem.Setup(lines);

            int result = problem.Part();
            Assert.That(result, Is.EqualTo(42));
        }
    }
}