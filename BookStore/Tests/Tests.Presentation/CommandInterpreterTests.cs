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
        [Test]
        public void CanViewWelcomeMessage_Success()
        {
            var commandInterpeter = new CommandInterpreter();

            var result = commandInterpeter.GetWelcomeMessage();

            Assert.AreEqual("Welcome to Fisher Books -- Books that hook you line and sinker!", result);
        }

        [Test]
        public void OnCommandErrorWillDisplayError()
        {
            var commandInterpreter = new CommandInterpreter();

            var commandFactory = new Mock<ICommandFactory>();

            commandFactory.Setup(x => x.ExecuteCommand(string.Empty)).Returns(new CommandResult
                                                                              {
                                                                                  WasSuccessful = false,
                                                                                  Message = "something went wrong"
                                                                              });

            commandInterpreter.CommandFactory = commandFactory.Object;

            var result = commandInterpreter.Execute(string.Empty);

            Assert.AreEqual("Error - something went wrong", result);
        }
    }
}