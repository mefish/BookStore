using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;

namespace BookStore.Domain.Commands
{
    class StockBookCommand
    {
        public CommandResult Execute(string commandParameters)
        {
            return new CommandResult();
        }

        public IBookInventory BookInventory { get; set; }
    }
}
