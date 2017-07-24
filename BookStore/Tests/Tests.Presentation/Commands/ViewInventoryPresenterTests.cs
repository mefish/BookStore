using System.Collections.Generic;
using System.Linq;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using BookStore.Presentation.Commands;
using BookStore.Tests.Tests.Common;
using Moq;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Presentation.Commands
{
    [TestFixture]
    internal class ViewInventoryPresenterTests
    {
        private readonly List<Book> _bookList = TestHelpers.TestBookList;
        private string _expectedString;
        private Mock<ICommandPresenterFactory> _factoryMock;
        private Mock<IBookInventory> _inventory;
        private ViewInventoryPresenter _presenter;

        [SetUp]
        public void Setup()
        {
            CreateFactoryMock();

            _presenter = new ViewInventoryPresenter(_factoryMock.Object);
        }

        [Test]
        public void CanBuildStringForASingleBook()
        {
            var book = _bookList.First();

            _expectedString = TestHelpers.ConvertBookToString(book);

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
            var expectedString = string.Concat(_bookList.Select(TestHelpers.ConvertBookToString));

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
    }
}