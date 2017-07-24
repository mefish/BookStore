using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using BookStore.Presentation.Commands;
using Moq;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Presentation.Commands
{
    [TestFixture]
    internal class ViewInventoryPresenterTests
    {
        private List<Book> _bookList;
        private string _expectedString;
        private Mock<ICommandPresenterFactory> _factoryMock;
        private Mock<IBookInventory> _inventory;
        private ViewInventoryPresenter _presenter;

        [SetUp]
        public void Setup()
        {
            CreateBookList();

            CreateFactoryMock();

            _presenter = new ViewInventoryPresenter(_factoryMock.Object);
        }

        [Test]
        public void CanBuildStringForASingleBook()
        {
            var book = _bookList.First();

            _expectedString = BuildStringForBook(book);

            var result = _presenter.ViewBookAsString(book);

            Assert.AreEqual(_expectedString, result);
        }

        [Test]
        public void WillReturnSuccessfulCommandResult()
        {
            var result = _presenter.ExecuteCommand();

            Assert.IsTrue(result.WasSuccessful);
        }

        [Test]
        public void OnExecuteCommandWillRetrieveBooksFromInventory()
        {
            _presenter.ExecuteCommand();

            _inventory.VerifyAll();
        }

        [Test]
        public void CanBuildStringForListOfBooks()
        {
            var expectedString = string.Concat(_bookList.Select(BuildStringForBook));

            var result = _presenter.PrintResult();

            Assert.AreEqual(expectedString, result);
        }

        private void CreateFactoryMock()
        {
            _factoryMock = new Mock<ICommandPresenterFactory>();

            CreateInventory();

            _factoryMock.Setup(x => x.BookInventory).Returns(_inventory.Object);
        }

        private void CreateInventory()
        {
            _inventory = new Mock<IBookInventory>();

            _inventory.Setup(x => x.GetAllBooks()).Returns(_bookList);
        }

        private void CreateBookList()
        {
            _bookList = new List<Book>
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
        }

        private static string BuildStringForBook(Book book)
        {
            return $"ISBN: {book.ISBN} Title: {book.Title} Author: {book.Author} Price: ${book.Price}{Environment.NewLine}";
        }
    }
}