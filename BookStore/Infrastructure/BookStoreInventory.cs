using System.Collections.Generic;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;

namespace BookStore.Infrastructure
{
    internal class BookStoreInventory : IBookInventory
    {
        private readonly List<Book> _booksInInventory = new List<Book>();

        public BookStoreInventory()
        {
            
        }

        public void AddToInventory(Book book)
        {
            _booksInInventory.Add(book); 
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _booksInInventory;
        }

        public void ClearInventory()
        {
            _booksInInventory.Clear();
        }
    }
}