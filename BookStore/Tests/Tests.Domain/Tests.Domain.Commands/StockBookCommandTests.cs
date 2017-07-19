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

            var result = command.Execute(string.Empty);

            Assert.IsFalse(result.WasSuccessful);
        }

        [Test]
        public void BooksWithoutTitlesAreNotAddedToInventory()
        {
            var command = new StockBookCommand();

            var bookInventory = new Mock<IBookInventory>();

            bookInventory.Setup(x => x.AddToInventory(It.IsAny<Book>()));

            command.BookInventory = bookInventory.Object;

            command.Execute(string.Empty);

            bookInventory.Verify(x => x.AddToInventory(It.IsAny<Book>()), Times.Never);
        }
    }
}