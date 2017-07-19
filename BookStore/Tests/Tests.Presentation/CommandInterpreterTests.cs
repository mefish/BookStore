using System.ComponentModel.Design.Serialization;
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
        private Mock<ICommandParser> _commandParser;
        private Mock<ICommand> _commandMock;

        [SetUp]
        public void SetUp()
        {
            _commandInterpreter = new CommandInterpreter();

            _commandFactory = new Mock<ICommandFactory>();

            _commandInterpreter.CommandFactory = _commandFactory.Object;

            _commandParser = new Mock<ICommandParser>();

            _commandInterpreter.CommandParser = _commandParser.Object;

            _commandMock = new Mock<ICommand>();
        }

        [Test]
        public void CanViewWelcomeMessage_Success()
        {
            var result = _commandInterpreter.GetWelcomeMessage();

            Assert.AreEqual(WELCOME_MESSAGE, result);
        }

        [Test]
        public void CommandWillBeExecutedWhenBuild()
        {
            SetUpCommandToReturnCommandResult();

            _commandParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(new string[1]);

            _commandFactory.Setup(x => x.BuildCommand(It.IsAny<string[]>())).Returns(_commandMock.Object);

            _commandInterpreter.Execute(string.Empty);

            _commandMock.VerifyAll();
        }

        private void SetUpCommandToReturnCommandResult(string message = "")
        {
            _commandMock.Setup(x => x.Execute()).Returns(new CommandResult
                                                         {
                                                             Message = message
                                                         });
        }

        [Test]
        public void CommandsAreParsedThroughCommandParser()
        {
            _commandParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(new string[1]);

            _commandFactory.Setup(x => x.BuildCommand(It.IsAny<string[]>())).Returns(_commandMock.Object);

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
            _commandParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(new string[1]);

            _commandFactory.Setup(x => x.BuildCommand(It.IsAny<string[]>())).Returns(_commandMock.Object);

            var response = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual("Unknown Error", response);
        }

        [Test]
        public void OnCommandErrorWillDisplayError()
        {
            _commandFactory.Setup(x => x.BuildCommand(new string[0])).Returns(_commandMock.Object);

            SetUpCommandToReturnCommandResult("something went wrong");

            var result = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual("Error - something went wrong", result);
        }

        [Test]
        public void OnCommandWillDisplayErrorMessage()
        {
            _commandFactory.Setup(x => x.BuildCommand(It.IsAny<string[]>())).Returns(_commandMock.Object);
            
            SetUpCommandToReturnCommandResult("you can't do that!");

            var result = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual("Error - you can't do that!", result);
        }
    }
}