using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using BookStore.Domain.Commands;

namespace BookStore.Domain
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand BuildCommand(string[] empty)
        {
            var command = new CommandNotFoundCommand();
            return command;
        }
    }
}
