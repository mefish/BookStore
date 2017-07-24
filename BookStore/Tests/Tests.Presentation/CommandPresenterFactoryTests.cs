using System;
using System.Linq;
using BookStore.Presentation;
using BookStore.Presentation.Commands;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Presentation
{
    [TestFixture]
    internal class CommandPresenterFactoryTests
    {
        private CommandPresenterFactory _commandPresenterFactory;

        [SetUp]
        public void Setup()
        {
            _commandPresenterFactory = new CommandPresenterFactory();
        }

        [Test]
        public void CommandNotFoundReturnsACommandNotFound()
        {
            var command = _commandPresenterFactory.BuildPresnter(new string[0]);

            var result = command.ExecuteCommand();

            Assert.IsFalse(result.WasSuccessful);
        }

        [TestCase(CommandStrings.STOCK_BOOK_COMMAND, typeof(StockBookPresenter))]
        [TestCase(CommandStrings.INVENTORY_COMMAND, typeof(ViewInventoryPresenter))]
        public void WillBuildPresenterForCommand(string command, Type expectedtype)
        {
            var commandFactory = _commandPresenterFactory.BuildPresnter(new[]
                                                                        {
                                                                            command
                                                                        });

            Assert.AreEqual(expectedtype, commandFactory.GetType());
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

            var command = _commandPresenterFactory.BuildPresnter(commandToBuild);

            Assert.IsTrue(expectedParameters.SequenceEqual(command.Parameters));
        }
    }
}