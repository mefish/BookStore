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
        private Mock<ICommandPresenterFactory> _commandFactory;
        private CommandInterpreter _commandInterpreter;
        private Mock<ICommandParser> _commandParser;
        private Mock<IPresenter> _presenterMock;

        [SetUp]
        public void SetUp()
        {
            _commandInterpreter = new CommandInterpreter();

            CreateCommandFactory();

            CreateCommandParser();

            _presenterMock = new Mock<IPresenter>();
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

            SetUpPresenterFactory();

            _commandInterpreter.Execute(string.Empty);

            _presenterMock.VerifyAll();
        }

        [Test]
        public void CommandWillCallFactoryToPopulatePropertiesFromAgruments()
        {
            SetUpParser();

            SetUpPresenterFactory();

            _presenterMock.Setup(x => x.BuildPropertiesFromParameters());

            _commandInterpreter.Execute(string.Empty);

            _presenterMock.VerifyAll();
        }

        [Test]
        public void SuccessfulCommandsReturnSuccess()
        {
            SetUpParser();

            SetUpPresenterFactory();

            var successMessage = "It worked!";

            SetUpCommand(true, successMessage);

            var result = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual($"Success - {successMessage}", result);
        }

        [Test]
        public void CommandsAreParsedThroughCommandParser()
        {
            SetUpParser();

            SetUpPresenterFactory();

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

            _commandFactory.Setup(x => x.BuildPresnter(stringArrayToReturn)).Returns(_presenterMock.Object);

            _commandInterpreter.Execute(string.Empty);

            _commandParser.VerifyAll();
        }

        [Test]
        public void IfCommandHasNoResultReportUnknownError()
        {
            SetUpParser();

            SetUpPresenterFactory();

            var response = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual("Unknown Error", response);
        }

        [Test]
        public void OnCommandErrorWillDisplayError()
        {
            _commandFactory.Setup(x => x.BuildPresnter(new string[0])).Returns(_presenterMock.Object);

            var errorMessage = "something went wrong";

            SetUpCommand(false, errorMessage);

            var result = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual($"Error - {errorMessage}", result);
        }

        [Test]
        public void OnCommandWillDisplayErrorMessage()
        {
            SetUpPresenterFactory();

            var errorMessage = "you can't do that!";

            SetUpCommand(false, errorMessage);

            var result = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual($"Error - {errorMessage}", result);
        }

        private void SetUpParser()
        {
            _commandParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(new string[1]);
        }

        private void SetUpPresenterFactory()
        {
            _commandFactory.Setup(x => x.BuildPresnter(It.IsAny<string[]>())).Returns(_presenterMock.Object);
        }

        private void CreateCommandParser()
        {
            _commandParser = new Mock<ICommandParser>();

            _commandInterpreter.CommandParser = _commandParser.Object;
        }

        private void CreateCommandFactory()
        {
            _commandFactory = new Mock<ICommandPresenterFactory>();

            _commandInterpreter.CommandPresenterFactory = _commandFactory.Object;
        }

        private void SetUpCommand(bool wasSuccussful, string message = "")
        {
            var commandResult = new CommandResult
                                {
                                    Message = message,
                                    WasSuccessful = wasSuccussful
                                };

            _presenterMock.Setup(x => x.ExecuteCommand()).Returns(commandResult);
        }
    }
}