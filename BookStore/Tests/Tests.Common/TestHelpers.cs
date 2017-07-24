using System;
using System.Collections.Generic;
using BookStore.Core.Core.Models;

namespace BookStore.Tests.Tests.Common
{
    internal static class TestHelpers
    {
        public static readonly List<Book> TestBookList = new List<Book>
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

        public static string ConvertBookToString(Book book)
        {
            return $"ISBN: {book.ISBN} Title: {book.Title} Author: {book.Author} Price: ${book.Price}{Environment.NewLine}";
        }

        public static List<Book> GetTestBookList()
        {
            return new List<Book>();
        }
    }
}