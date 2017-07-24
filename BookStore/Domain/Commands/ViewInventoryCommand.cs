using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;

namespace BookStore.Domain.Commands
{
    class ViewInventoryCommand
    {
        private readonly IBookInventory _bookInventory;

        public ViewInventoryCommand(ICommandPresenterFactory presenterFactory)
        {
            _bookInventory = presenterFactory.BookInventory;
        }

        public IEnumerable<Book> InventoryList { get; set; }

        public CommandResult Execute()
        {
            InventoryList = _bookInventory.GetAllBooks();
            return new CommandResult
                   {
                       WasSuccessful = true
                   };
        }
    }
}
