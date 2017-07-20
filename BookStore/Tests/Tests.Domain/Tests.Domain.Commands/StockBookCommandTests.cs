using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using BookStore.Domain.Commands;
using Moq;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Domain.Tests.Domain.Commands
{
    [TestFixture]
    internal class StockBookCommandTests
    {
        private const string ISBN = "123";
        private Mock<IBookInventory> _bookInventoryMock;
        private StockBookCommand _command;
        private Mock<ICommandFactory> _commandFactory;

        [SetUp]
        public void Setup()
        {
            _commandFactory = new Mock<ICommandFactory>();

            SetUpBookInventory();

            _command = new StockBookCommand(_commandFactory.Object);
        }

        private void SetUpBookInventory()
        {
            _bookInventoryMock = new Mock<IBookInventory>();

            _commandFactory.Setup(x => x.BookInventory).Returns(_bookInventoryMock.Object);
        }

        [Test]
        public void StockingABookWithoutISBNFails()
        {
            var result = _command.Execute();

            Assert.IsFalse(result.WasSuccessful);
        }

        [Test]
        public void CanBuildISBNFromParameters()
        {
            _command.Parameters = new[]
                                  {
                                      ISBN
                                  };

            _command.BuildPropertiesFromParameters();

            Assert.AreEqual(ISBN, _command.ISBN);
        }

        [Test]
        public void OnStoreSuccessWillReturnSuccess()
        {
            _command.Parameters = new[]
                                  {
                                      ISBN
                                  };

            _bookInventoryMock.Setup(x => x.AddToInventory(It.IsAny<Book>()));

            _command.BuildPropertiesFromParameters();

           var result = _command.Execute();

            Assert.IsTrue(result.WasSuccessful);
        }

        [Test]
        public void BooksWithISBNAreAddedToInventory()
        {
            _command.Parameters = new[]
                                  {
                                      ISBN
                                  };

            Book book = null;

            _bookInventoryMock.Setup(x => x.AddToInventory(It.IsAny<Book>()))
                              .Callback((Book bookToAdd) => book = bookToAdd);

            _command.BuildPropertiesFromParameters();

            _command.Execute();

            Assert.AreEqual(ISBN, book.ISBN);
        }
    }
}