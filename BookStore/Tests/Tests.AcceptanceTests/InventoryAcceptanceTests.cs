using System.Collections.Generic;
using System.Linq;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using BookStore.Presentation.Commands;
using BookStore.Tests.Tests.Common;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace BookStore.Tests.Tests.AcceptanceTests
{
    [TestFixture]
    internal class InventoryAcceptanceTests
    {
        private IBookInventory _bookInventory;
        private ICommandInterpreter _commandInterpreter;

        [SetUp]
        public void SetUp()
        {
            _commandInterpreter = Configuration.UnityContainer.Resolve<ICommandInterpreter>();

            _bookInventory = Configuration.UnityContainer.Resolve<IBookInventory>();

            _bookInventory.ClearInventory();
        }

        [Test]
        public void CanAddBookToInventorySuccess()
        {
            var result = _commandInterpreter.Execute(@"stock 123 ""The Stranger"" ""Camus""");

            var newBook = _bookInventory.GetAllBooks().First(x => x.ISBN == "123");

            Assert.AreEqual("123", newBook.ISBN);
        }

        [Test]
        public void ICanViewAllBooksInInventory()
        {
            var bookList = TestHelpers.TestBookList;

            AddListOfBooksToBookInventory(bookList);

            var resultList = bookList.Select(TestHelpers.ConvertBookToString);

            var expected = string.Concat(resultList);

            var result = _commandInterpreter.Execute(CommandStrings.INVENTORY_COMMAND);

            Assert.AreEqual(expected, result);
        }

        private void AddListOfBooksToBookInventory(List<Book> bookList)
        {
            foreach (var book in bookList) _bookInventory.AddToInventory(book);
        }
    }
}