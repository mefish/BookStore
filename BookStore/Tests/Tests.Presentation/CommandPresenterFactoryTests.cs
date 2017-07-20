using System.Linq;
using BookStore.Domain;
using BookStore.Presentation.Commands;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Domain
{
    [TestFixture]
    internal class CommandPresenterFactoryTests
    {
        private CommandPresenterPresenterFactory _commandPresenterPresenterFactory;

        [SetUp]
        public void Setup()
        {
            _commandPresenterPresenterFactory = new CommandPresenterPresenterFactory();
        }

        [Test]
        public void CommandNotFoundReturnsACommandNotFound()
        {
            var command = _commandPresenterPresenterFactory.BuildPresnter(new string[0]);

            var result = command.ExecuteCommand();

            Assert.IsFalse(result.WasSuccessful);
        }

        [Test]
        public void WillBuildStockBookPresenter()
        {
            var command = _commandPresenterPresenterFactory.BuildPresnter(new[]
                                                                         {
                                                                             "stock"
                                                                         });

            Assert.AreEqual(typeof(StockBookPresenter), command.GetType());
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

            var command = _commandPresenterPresenterFactory.BuildPresnter(commandToBuild);

            Assert.IsTrue(expectedParameters.SequenceEqual(command.Parameters));
        }
    }
}