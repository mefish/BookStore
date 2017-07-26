using System.Collections.Generic;
using BookStore.Core.Core.Models;

namespace BookStore.Infrastructure
{
    internal class DemonstrationBookStoreInventory : BookStoreInventory
    {
        public DemonstrationBookStoreInventory()
        {
            AddTestBooksToInventory();
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