using System.Collections.Generic;
using BookStore.Core.Core.Models;

namespace BookStore.Core.Core.Interfaces
{
    public interface IBookInventory
    {
        void AddToInventory(Book bookToAdd);

        IEnumerable<Book> GetAllBooks();
    }
}