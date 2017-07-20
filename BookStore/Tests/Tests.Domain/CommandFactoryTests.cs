using System.Linq;
using BookStore.Domain;
using BookStore.Domain.Commands;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Domain
{
    [TestFixture]
    internal class CommandFactoryTests
    {
        private CommandFactory _commandFactory;

        public void Setup()
        {
            _commandFactory = new CommandFactory();
        }

        [Test]
        public void CommandNotFoundReturnsACommandNotFound()
        {
            var command = _commandFactory.BuildCommand(new string[0]);

            var result = command.Execute();

            Assert.IsFalse(result.WasSuccessful);
        }

        [Test]
        public void WillBuildStockBookCommand()
        {
            var command = _commandFactory.BuildCommand(new[]
                                                       {
                                                           "stock"
                                                       });

            Assert.AreEqual(typeof(StockBookCommand), command.GetType());
        }

        [Test]
        public void CommandArgumentsAreAddedtoCommandParameters()
        {
            var commandToBuild = new[]
                                 {
                                     "stock",
                                     "hello",
                                     "how",
                                     "are",
                                     "you"
                                 };

            var expectedParameters = commandToBuild.Skip(1);

            var command = _commandFactory.BuildCommand(commandToBuild);

            Assert.IsTrue(expectedParameters.SequenceEqual(command.Parameters));
        }
    }
}