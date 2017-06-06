using NUnit.Framework;

namespace AoC._2015._07
{
    [TestFixture]
    public class Problem07Tests
    {
        [TestCase("a", "b", ExpectedResult = false)]
        [TestCase("a", "1", ExpectedResult = false)]
        [TestCase("2", "b", ExpectedResult = false)]
        [TestCase("2", "1", ExpectedResult = true)]
        public bool ThatTheCalculableCheckWorksCorrectly(string left, string right)
        {
            var exp = new Expression
            {
                LeftValue = left,
                Operation = "AND",
                RightValue = right
            };

            return exp.IsCalculable();
        }

        [TestCase("AND", ExpectedResult = 1)]
        [TestCase("OR", ExpectedResult = 5)]
        [TestCase("RSHIFT", ExpectedResult = 2)]
        [TestCase("LSHIFT", ExpectedResult = 10)]
        public int? ThatAValidExpressionIsCalculable(string operation)
        {
            var exp = new Expression
            {
                LeftValue = "5",
                Operation = operation,
                RightValue = "1"
            };

            return exp.Calculate();
        }

        [TestCase("55", ExpectedResult = -56)]
        public int? ThatTheNotCalculationWorksCorrectky(string value)
        {
            var exp = new Expression
            {
                Operation = "NOT",
                RightValue = value
            };

            return exp.Calculate();
        }
    }
}