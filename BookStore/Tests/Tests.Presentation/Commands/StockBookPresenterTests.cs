using BookStore.Core.Core.Interfaces;
using BookStore.Presentation.Commands;
using Moq;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Presentation.Commands
{
    [TestFixture]
    internal class StockBookPresenterTests
    {
        private const string ISBN = "456";
        private Mock<ICommandPresenterFactory> _factoryMock;

        private StockBookPresenter _presenter;

        [SetUp]
        public void Setup()
        {
            _factoryMock = new Mock<ICommandPresenterFactory>();

            _presenter = new StockBookPresenter(_factoryMock.Object);
        }

        [Test]
        public void OnSuccessWillPrintSuccessMessage()
        {
            var bookInventoryMock = new Mock<IBookInventory>();

            _presenter.BookInventory = bookInventoryMock.Object;

            _presenter.ISBN = ISBN;

            var result = _presenter.PrintResult();

            Assert.AreEqual($"Successfully added book with ISBN# {ISBN} to inventory!", result);
        }

        [Test]
        public void CanBuildBookFromParameters()
        {
            var title = "Title";
            var author = "Author";

            _presenter.Parameters = new[]
                                    {
                                        ISBN,
                                        title,
                                        author,
                                    };

            _presenter.BuildPropertiesFromParameters();

            Assert.AreEqual(ISBN, _presenter.ISBN);
            Assert.AreEqual(title, _presenter.Title);
            Assert.AreEqual(author, _presenter.Author);
        }
    }
}