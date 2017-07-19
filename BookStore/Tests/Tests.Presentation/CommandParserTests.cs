using BookStore.Presentation;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Presentation
{
    [TestFixture]
    internal class CommandParserTests
    {
        private CommandParser _commandParser;
        private string[] _result;

        [SetUp]
        public void SetUp()
        {
            _commandParser = new CommandParser();
        }

        [Test]
        public void CanParseEmptyCommand()
        {
            var command = string.Empty;

            ParseCommand(command);

            Assert.AreEqual(string.Empty, _result[0]);
        }

        private void ParseCommand(string command)
        {
            _result = _commandParser.Parse(command);
        }

        [Test]
        public void ReturnsCommandAtFirstIndex()
        {
            var command = "command";

            ParseCommand(command);

            Assert.AreEqual(command, _result[0]);
        }

        [Test]
        public void ReturnsArgumentAsSecondIndex()
        {
            var command = "command argument";

            ParseCommand(command);

            Assert.AreEqual("argument", _result[1]);
        }

        [Test]
        public void ArgumentsWithQuotesAreMaintainedWhenParsing()
        {
            var command = @"""multiple words""";

            ParseCommand(command);

            Assert.AreEqual(command, _result[0]);
        }
    }
}