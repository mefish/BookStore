using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Core.Interfaces;
using Microsoft.Practices.Unity;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace BookStore.Tests.Tests.AcceptanceTests
{
    [TestFixture]
    class InventoryTests
    {
        [Test]
        public void CanAddBookToInventorySuccess()
        {
            var commandInterpreter = Configuration.UnityContainer.Resolve<ICommandInterpreter>();

            var data = Configuration.UnityContainer.Resolve<IBookInventory>();

            var result = commandInterpreter.Execute(@"stock 123 ""The Stranger"" ""Camus""");

            var newBook = data.GetAllBooks().First(x => x.ISBN == "123");

            Assert.AreEqual("123", newBook.ISBN);
        }
    }
}
