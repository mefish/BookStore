using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;

namespace BookStore.Domain.Commands
{
    class CommandNotFoundCommand : ICommand
    {
        public CommandResult Execute()
        {
            return new CommandResult();
        }
    }
}
