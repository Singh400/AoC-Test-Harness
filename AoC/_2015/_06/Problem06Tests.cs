using NUnit.Framework;

namespace AoC._2015._06
{
    [TestFixture]
    public class Problem06Tests
    {
        [Test]
        public void ThatOnInstructionsAreParsedCorrectly()
        {
            var actualInstruction = Problem_2015_06.ParseLine("turn on 887,9 through 959,629");
            Assert.That(actualInstruction.Operation, Is.EqualTo(1));
            Assert.That(actualInstruction.RowStart, Is.EqualTo(887));
            Assert.That(actualInstruction.ColumnStart, Is.EqualTo(9));
            Assert.That(actualInstruction.RowFinish, Is.EqualTo(959));
            Assert.That(actualInstruction.ColumnFinish, Is.EqualTo(629));
        }

        [Test]
        public void ThatOffInstructionsAreParsedCorrectly()
        {
            var actualInstruction = Problem_2015_06.ParseLine("turn off 539,243 through 559,965");
            Assert.That(actualInstruction.Operation, Is.EqualTo(0));
            Assert.That(actualInstruction.RowStart, Is.EqualTo(539));
            Assert.That(actualInstruction.ColumnStart, Is.EqualTo(243));
            Assert.That(actualInstruction.RowFinish, Is.EqualTo(559));
            Assert.That(actualInstruction.ColumnFinish, Is.EqualTo(965));
        }

        [Test]
        public void ThatToggleInstructionsAreParsedCorrectly()
        {
            var actualInstruction = Problem_2015_06.ParseLine("toggle 720,196 through 897,994");
            Assert.That(actualInstruction.Operation, Is.EqualTo(2));
            Assert.That(actualInstruction.RowStart, Is.EqualTo(720));
            Assert.That(actualInstruction.ColumnStart, Is.EqualTo(196));
            Assert.That(actualInstruction.RowFinish, Is.EqualTo(897));
            Assert.That(actualInstruction.ColumnFinish, Is.EqualTo(994));
        }
    }
}