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
        private Mock<ICommandFactory> _commandFactory;
        private CommandInterpreter _commandInterpreter;

        [SetUp]
        public void SetUp()
        {
            _commandInterpreter = new CommandInterpreter();
            _commandFactory = new Mock<ICommandFactory>();
        }

        [Test]
        public void CanViewWelcomeMessage_Success()
        {
            var result = _commandInterpreter.GetWelcomeMessage();

            Assert.AreEqual("Welcome to Fisher Books -- Books that hook you line and sinker!", result);
        }

        [Test]
        public void OnCommandErrorWillDisplayError()
        {
            _commandFactory.Setup(x => x.ExecuteCommand(string.Empty)).Returns(new CommandResult
                                                                               {
                                                                                   WasSuccessful = false,
                                                                                   Message = "something went wrong"
                                                                               });

            _commandInterpreter.CommandFactory = _commandFactory.Object;

            var result = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual("Error - something went wrong", result);
        }

        [Test]
        public void OnCommandWillDisplayErrorMessage()
        {
            _commandFactory.Setup(x => x.ExecuteCommand(string.Empty)).Returns(new CommandResult
                                                                               {
                                                                                   WasSuccessful = false,
                                                                                   Message = "you can't do that!"
                                                                               });

            _commandInterpreter.CommandFactory = _commandFactory.Object;

            var result = _commandInterpreter.Execute(string.Empty);

            Assert.AreEqual("Error - you can't do that!", result);
        }
    }
}