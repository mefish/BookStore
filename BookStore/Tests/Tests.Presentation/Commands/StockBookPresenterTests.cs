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
        private const string EXPECTED_TITLE = "Title";
        private const string EXPECTED_AUTHOR = "Author";
        private Mock<ICommandPresenterFactory> _factoryMock;

        private StockBookPresenter _presenter;

        private string[] _presenterParameters = new[]
                                                {
                                                    ISBN,
                                                    EXPECTED_TITLE,
                                                    EXPECTED_AUTHOR,
                                                };

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
        public void CanAddTitleWithParameters()
        {
            _presenter.Parameters = _presenterParameters;

            _presenter.BuildPropertiesFromParameters();

            Assert.AreEqual(EXPECTED_TITLE, _presenter.Title);
        }

        [Test]
        public void CanAddAuthorWithParameters()
        {
            _presenter.Parameters = _presenterParameters;

            _presenter.BuildPropertiesFromParameters();

            Assert.AreEqual(EXPECTED_AUTHOR, _presenter.Author);
        }
    }
}