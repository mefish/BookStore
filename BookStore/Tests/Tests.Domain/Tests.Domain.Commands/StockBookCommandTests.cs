using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using BookStore.Domain.Commands;
using DeepEqual.Syntax;
using Moq;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Domain.Tests.Domain.Commands
{
    [TestFixture]
    internal class StockBookCommandTests
    {
        private const string COMMAND_ISBN = "123";
        private const string COMMAND_AUTHOR = "author";
        private const string COMMAND_TITLE = "title";
        private Mock<IBookInventory> _bookInventoryMock;
        private StockBookCommand _command;
        private Mock<ICommandPresenterFactory> _commandFactory;

        [SetUp]
        public void Setup()
        {
            _commandFactory = new Mock<ICommandPresenterFactory>();

            SetUpBookInventory();

            _command = new StockBookCommand(_commandFactory.Object);

            _command.ISBN = COMMAND_ISBN;
            _command.Author = COMMAND_AUTHOR;
            _command.Title = COMMAND_TITLE;
        }

        [Test]
        public void StockingABookWithoutISBNFails()
        {
            _command.ISBN = null;

            var result = _command.Execute();

            Assert.IsFalse(result.WasSuccessful);
        }

        [Test]
        public void OnStoreSuccessWillReturnSuccess()
        {
            _bookInventoryMock.Setup(x => x.AddToInventory(It.IsAny<Book>()));

            var result = _command.Execute();

            Assert.IsTrue(result.WasSuccessful);
        }

        [Test]
        public void BooksWithISBNAreAddedToInventory()
        {
            Book book = null;

            _bookInventoryMock.Setup(x => x.AddToInventory(It.IsAny<Book>()))
                              .Callback((Book bookToAdd) => book = bookToAdd);

            _command.Execute();

            Assert.AreEqual(COMMAND_ISBN, book.ISBN);
        }

        [Test]
        public void CompleteBookCanBeAddedToInventory()
        {
            var bookToCreate = new Book
                               {
                                   Author = COMMAND_AUTHOR,
                                   ISBN = COMMAND_ISBN,
                                   Title = COMMAND_TITLE
                               };

            Book bookCreated = null;

            _bookInventoryMock.Setup(x => x.AddToInventory(It.IsAny<Book>()))
                              .Callback((Book book) => bookCreated = book);

            _command.Execute();

            Assert.IsTrue(bookToCreate.IsDeepEqual(bookCreated));
        }

        private void SetUpBookInventory()
        {
            _bookInventoryMock = new Mock<IBookInventory>();

            _commandFactory.Setup(x => x.BookInventory).Returns(_bookInventoryMock.Object);
        }
    }
}