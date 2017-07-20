using System.Linq;
using BookStore.Core.Core.Interfaces;
using BookStore.Domain;
using BookStore.Domain.Commands;
using Moq;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Domain
{
    [TestFixture]
    internal class CommandFactoryTests
    {
        [Test]
        public void CommandNotFoundReturnsACommandNotFound()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.BuildCommand(new string[0]);

            var result = command.Execute();

            Assert.IsFalse(result.WasSuccessful);
        }

        [Test]
        public void WillBuildStockBookCommand()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.BuildCommand(new[]
                                                      {
                                                          "stock"
                                                      });

            Assert.AreEqual(typeof(StockBookCommand), command.GetType());
        }
    }

    internal class TestCommand { }
}