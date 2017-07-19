using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;

namespace BookStore.Domain.Commands
{
    class StockBookCommand : ICommand
    {
        public CommandResult Execute(string commandParameters)
        {
            if (commandParameters == string.Empty) return new CommandResult();

            var bookToAdd = new Book
                            {
                                ISBN = "123"
                            };

            BookInventory.AddToInventory(bookToAdd);

            return new CommandResult();
        }

        public IBookInventory BookInventory { get; set; }

        public CommandResult Execute()
        {
            throw new NotImplementedException();
        }
    }
}
