using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Core.Models;
using BookStore.Infrastructure;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Infrastructure
{
    [TestFixture]
    class BookStoreInventoryTests
    {
        [Test]
        public void CanStockABookInInventory()
        {
            var inventory = new BookStoreInventory();
            
            var book = new Book();

            inventory.AddToInventory(book);

            Assert.IsTrue(inventory.GetAllBooks().Contains(book));

        }
    }
}
