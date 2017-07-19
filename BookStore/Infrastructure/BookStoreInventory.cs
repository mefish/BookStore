using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;

namespace BookStore.Infrastructure
{
    class BookStoreInventory : IBookInventory
    {
        private List<Book> _booksInInventory = new List<Book>();

        public void AddToInventory(Book book)
        {
            _booksInInventory.Add(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _booksInInventory;
        }
    }
}
