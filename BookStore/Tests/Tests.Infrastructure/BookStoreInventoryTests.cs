using System.Linq;
using BookStore.Core.Core.Models;
using BookStore.Infrastructure;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Infrastructure
{
    [TestFixture]
    internal class BookStoreInventoryTests
    {
        private Book _book;
        private BookStoreInventory _bookInventory;

        [SetUp]
        public void Setup()
        {
            _bookInventory = new BookStoreInventory();
            _book = new Book();
        }

        [Test]
        public void CanStockABookInInventory()
        {
            _bookInventory.AddToInventory(_book);

            Assert.IsTrue(_bookInventory.GetAllBooks().Contains(_book));
        }

        [Test]
        public void CanDeleteAllBooksFromInventory()
        {
            _bookInventory.AddToInventory(_book);

            _bookInventory.ClearInventory();

            Assert.IsEmpty(_bookInventory.GetAllBooks());
        }
    }
}