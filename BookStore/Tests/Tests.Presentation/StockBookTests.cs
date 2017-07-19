using BookStore.Presentation;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Presentation
{
    [TestFixture]
    internal class StockBookTests
    {
        [Test]
        public void CanViewWelcomeMessage_Success()
        {
            var commandInterpeter = new CommandInterpreter();

            var result = commandInterpeter.GetWelcomeMessage();

            Assert.AreEqual("Welcome to Fisher Books -- Books that hook you line and sinker!", result);
        }
    }
}