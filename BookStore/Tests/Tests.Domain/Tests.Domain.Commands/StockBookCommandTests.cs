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
    class StockBookCommandTests
    {
        [Test]
        public void StockingABookWithoutATitle_Fails()
        {
            var command = new StockBookCommand();

            var result = command.Execute(string.Empty);

            Assert.IsFalse(result.WasSuccessful);
        }


    }
}
