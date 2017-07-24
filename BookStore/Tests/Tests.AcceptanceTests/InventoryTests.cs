using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace BookStore.Tests.Tests.AcceptanceTests
{
    [TestFixture]
    internal class InventoryTests
    {
        [TearDown]
        public void Teardown()
        {
            var data = Configuration.UnityContainer.Resolve<IBookInventory>();

            data.ClearInventory();
        }

        [Test]
        public void CanAddBookToInventorySuccess()
        {
            var commandInterpreter = Configuration.UnityContainer.Resolve<ICommandInterpreter>();

            var data = Configuration.UnityContainer.Resolve<IBookInventory>();

            var result = commandInterpreter.Execute(@"stock 123 ""The Stranger"" ""Camus""");

            var newBook = data.GetAllBooks().First(x => x.ISBN == "123");

            Assert.AreEqual("123", newBook.ISBN);
        }

        [Test]
        public void ICanViewAllBooksInInventory()
        {
            var commandInterpreter = Configuration.UnityContainer.Resolve<ICommandInterpreter>();

            var data = Configuration.UnityContainer.Resolve<IBookInventory>();

            var bookList = new List<Book>
                           {
                               new Book
                               {
                                   ISBN = "123",
                                   Title = "Meditations",
                                   Author = "Aurelius",
                                   Price = 12.50
                               },
                               new Book
                               {
                                   ISBN = "456",
                                   Title = "The Stranger",
                                   Author = "Camus",
                                   Price = 13.75
                               },
                               new Book
                               {
                                   ISBN = "789",
                                   Title = "Starship Troopers",
                                   Author = "Heinlein",
                                   Price = 15.60
                               }
                           };

            foreach (var book in bookList) data.AddToInventory(book);

            var resultList = bookList.Select(ConvertBookToString);

            var expectd = string.Concat(resultList);

            var result = commandInterpreter.Execute("inventory");

            Assert.AreEqual(expectd, result);
        }

        private string ConvertBookToString(Book book)
        {
            return $"ISBN: {book.ISBN} Title: {book.Title} Author: {book.Author} Price: ${book.Price}{Environment.NewLine}";
        }
    }
}