using NUnit.Framework;

namespace AoC._2016._09
{
    [TestFixture]
    public class Problem09Tests
    {
        private Problem_2016_09 _problem;

        [OneTimeSetUp]
        public void Setup() => _problem = new Problem_2016_09();

        [TestCase("A(1x5)BC", ExpectedResult = 7)]
        [TestCase("(3x3)XYZ", ExpectedResult = 9)]
        [TestCase("A(2x2)BCD(2x2)EFG", ExpectedResult = 11)]
        [TestCase("(6x1)(1x3)A", ExpectedResult = 6)]
        [TestCase("X(8x2)(3x3)ABCY", ExpectedResult = 18)]
        [TestCase("X(8x2)(3x3)ABCY", ExpectedResult = 18)]
        public int PartOne(string input) => _problem.PartOne(input);

        [TestCase("(27x12)(20x12)(13x14)(7x10)(1x12)A", ExpectedResult = 241920)]
        [TestCase("X(8x2)(3x3)ABCY", ExpectedResult = 20)]
        [TestCase("A(2x2)BCD(3x2)EFG", ExpectedResult = 12)]
        public long PartTwo(string input) => _problem.Explode(input.ToCharArray());

        [TestCase("(27x12)(20x12)(13x14)(7x10)(1x12)A", ExpectedResult = "(1x12)")]
        [TestCase("X(8x2)(3x3)ABCY", ExpectedResult = "(3x3)")]
        [TestCase("A(2x2)BCD(3x2)EFG", ExpectedResult = "(2x2)")]
        public string GetNextSection(string input) => _problem.GetNextSectionRec(input).Section;

        [TestCase("(27x12)(20x12)(13x14)(7x10)(1x12)A", ExpectedResult = 27)]
        [TestCase("X(8x2)(3x3)ABCY", ExpectedResult = 6)]
        [TestCase("A(2x2)BCD(3x2)EFG", ExpectedResult = 1)]
        public int GetNextSectionRecStartPos(string input) => _problem.GetNextSectionRec(input).StartPos;

        [TestCase("(27x12)(20x12)(13x14)(7x10)(1x12)A", ExpectedResult = 32)]
        [TestCase("X(8x2)(3x3)ABCY", ExpectedResult = 10)]
        [TestCase("A(2x2)BCD(3x2)EFG", ExpectedResult = 5)]
        public int GetNextSectionRecFinishPos(string input) => _problem.GetNextSectionRec(input).FinishPos;
    }
}