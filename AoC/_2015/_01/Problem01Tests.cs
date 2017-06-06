using NUnit.Framework;

namespace AoC._2015._01
{
    [TestFixture]
    public sealed class Problem01Tests
    {
        [TestCase('(', ExpectedResult = 1)]
        [TestCase(')', ExpectedResult = -1)]
        public int TheCharacterIsMappedCorrectly(char character) => Problem_2015_01.ParseCharacter(character);
    }
}