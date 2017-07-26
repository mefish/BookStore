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
            AddTestBooksToInventory();
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

        private void AddTestBooksToInventory()
        {
            var testBooks = new List<Book>
                            {
                                new Book
                                {
                                    ISBN = "123",
                                    Title = "Meditations",
                                    Author = "Aurelius",
                                    Price = 12.50
                                },
                                new Book
                                {
                                    ISBN = "456",
                                    Title = "The Stranger",
                                    Author = "Camus",
                                    Price = 13.75
                                },
                                new Book
                                {
                                    ISBN = "789",
                                    Title = "Starship Troopers",
                                    Author = "Heinlein",
                                    Price = 15.60
                                }
                            };

            foreach (var testBook in testBooks) AddToInventory(testBook);
        }
    }
}