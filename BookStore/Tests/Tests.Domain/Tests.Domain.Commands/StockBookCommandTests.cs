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
        [Test]
        public void StockingABookWithoutATitle_Fails()
        {
            var command = new StockBookCommand();

            var result = command.Execute();

            Assert.IsFalse(result.WasSuccessful);
        }

        [Test]
        public void CanBuildISBNFromParameters()
        {
            var isbn = "123";

            var command = new StockBookCommand
                          {
                Parameters = new[] { isbn }
            };

            command.BuildPropertiesFromParameters();

            Assert.AreEqual(isbn, command.ISBN);
        }


        [Test]
        [Ignore("In progress")]
        public void BooksWithISBNAreAddedToInventory()
        {
            var isbn = "123";
            var command = new StockBookCommand
                          {
                              Parameters = new [] {isbn}
                          };

            var bookInventory = new Mock<IBookInventory>();

            Book book = null;

            bookInventory.Setup(x => x.AddToInventory(It.IsAny<Book>()))
                         .Callback((Book bookToAdd) => book = bookToAdd);

            command.BookInventory = bookInventory.Object;

            command.BuildPropertiesFromParameters();

            command.Execute();

            Assert.AreEqual(isbn, book.ISBN);
        }
    }
}