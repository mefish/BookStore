using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using BookStore.Presentation;
using Moq;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Presentation
{
    [TestFixture]
    internal class CommandInterpreterTests
    {
        private const string WELCOME_MESSAGE = "Welcome to Fisher Books -- Books that hook you line and sinker!";
        private Mock<ICommandFactory> _commandFactory;
        private CommandInterpreter _commandInterpreter;
        private Mock<ICommand> _commandMock;
        private Mock<ICommandParser> _commandParser;

        [SetUp]
        public void SetUp()
        {
            _commandInterpreter = new CommandInterpreter();

            CreateCommandFactory();

            CreateCommandParser();

            _commandMock = new Mock<ICommand>();
        }

        [Test]
        public void CanViewWelcomeMessage_Success()
        {
            var result = _commandInterpreter.GetWelcomeMessage();

            Assert.AreEqual(WELCOME_MESSAGE, result);
        }

        [Test]
        public void CommandWillBeExecutedWhenBuilt()
        {
            SetUpCommand(false);

            SetUpParser();

            SetUpCommandFactory();

            _commandInterpreter.Execute(string.Empty);

            _commandMock.VerifyAll();
        }

        [Test]
        public void CommandWillCallFactoryToPopulatePropertiesFromAgruments()
        {
            SetUpParser();

            SetUpCommandFactory();

            _commandMock.Setup(x => x.BuildPropertiesFromParameters());

            _commandInterpreter.Execute(string.Empty);

            _commandMock.VerifyAll();
        }

        [Test]
        public void SuccessfulCommandsReturnSuccess()
        {
            SetUpParser();

            SetUpCommandFactory();

            var successMessage = "It worked!";

            SetUpCommand(true, successMessage);

            var result = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual($"Success - {successMessage}", result);
        }

        [Test]
        public void CommandsAreParsedThroughCommandParser()
        {
            SetUpParser();

            SetUpCommandFactory();

            _commandInterpreter.Execute(string.Empty);

            _commandParser.VerifyAll();
        }

        [Test]
        public void ParsedCommandArraysAreSentToCommandFactory()
        {
            var stringArrayToReturn = new[]
                                      {
                                          "hello", "how", "are", "you"
                                      };

            _commandParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(stringArrayToReturn);

            _commandFactory.Setup(x => x.BuildCommand(stringArrayToReturn)).Returns(_commandMock.Object);

            _commandInterpreter.Execute(string.Empty);

            _commandParser.VerifyAll();
        }

        [Test]
        public void IfCommandHasNoResultReportUnknownError()
        {
            SetUpParser();

            SetUpCommandFactory();

            var response = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual("Unknown Error", response);
        }

        [Test]
        public void OnCommandErrorWillDisplayError()
        {
            _commandFactory.Setup(x => x.BuildCommand(new string[0])).Returns(_commandMock.Object);

            var errorMessage = "something went wrong";

            SetUpCommand(false, errorMessage);

            var result = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual($"Error - {errorMessage}", result);
        }

        [Test]
        public void OnCommandWillDisplayErrorMessage()
        {
            SetUpCommandFactory();

            var errorMessage = "you can't do that!";

            SetUpCommand(false, errorMessage);

            var result = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual($"Error - {errorMessage}", result);
        }

        private void SetUpParser()
        {
            _commandParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(new string[1]);
        }

        private void SetUpCommandFactory()
        {
            _commandFactory.Setup(x => x.BuildCommand(It.IsAny<string[]>())).Returns(_commandMock.Object);
        }

        private void CreateCommandParser()
        {
            _commandParser = new Mock<ICommandParser>();

            _commandInterpreter.CommandParser = _commandParser.Object;
        }

        private void CreateCommandFactory()
        {
            _commandFactory = new Mock<ICommandFactory>();

            _commandInterpreter.CommandFactory = _commandFactory.Object;
        }

        private void SetUpCommand(bool wasSuccussful, string message = "")
        {
            var commandResult = new CommandResult
                                {
                                    Message = message,
                                    WasSuccessful = wasSuccussful
                                };

            _commandMock.Setup(x => x.Execute()).Returns(commandResult);
        }
    }
}