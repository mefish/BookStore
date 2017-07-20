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
        public void CanBuildISBNFromParameters()
        {
            _presenter.Parameters = new[]
                                    {
                                        ISBN
                                    };

            _presenter.BuildPropertiesFromParameters();

            Assert.AreEqual(ISBN, _presenter.ISBN);
        }
    }
}