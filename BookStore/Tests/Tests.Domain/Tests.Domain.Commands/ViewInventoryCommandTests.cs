using System.Collections.Generic;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using BookStore.Domain.Commands;
using BookStore.Tests.Tests.Common;
using Moq;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Domain.Tests.Domain.Commands
{
    [TestFixture]
    internal class ViewInventoryCommandTests
    {
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
            var bookList = TestHelpers.TestBookList;

            _bookInventoryMock.Setup(x => x.GetAllBooks()).Returns(bookList);

            var result = _command.Execute();

            Assert.AreEqual(bookList, _command.InventoryList);
        }
    }
}