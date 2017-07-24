using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using BookStore.Domain.Commands;
using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Domain.Tests.Domain.Commands
{
    [TestFixture]
    class ViewInventoryCommandTests
    {
        private const string ISBN = "123";
        private Mock<IBookInventory> _bookInventoryMock;
        private ViewInventoryCommand _command;
        private Mock<ICommandPresenterFactory> _commandFactory;

        [SetUp]
        public void Setup()
        {
            _commandFactory = new Mock<ICommandPresenterFactory>();

            SetUpBookInventory();

            _command = new ViewInventoryCommand(_commandFactory.Object);
        }

        private void SetUpBookInventory()
        {
            _bookInventoryMock = new Mock<IBookInventory>();

            _commandFactory.Setup(x => x.BookInventory).Returns(_bookInventoryMock.Object);
        }

        [Test]
        public void OnSuccessWillReturnSuccessfulCommandResultResult()
        {
            var result = _command.Execute();

            Assert.IsTrue(result.WasSuccessful);
        }

        [Test]
        public void WillReturnAllBooksInInventory()
        {
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
            _bookInventoryMock.Setup(x => x.GetAllBooks()).Returns(bookList);

            var result = _command.Execute();

            Assert.AreEqual(bookList, _command.InventoryList);
        }
    }
}
