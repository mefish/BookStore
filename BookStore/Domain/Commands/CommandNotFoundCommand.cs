using System;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;

namespace BookStore.Domain.Commands
{
    internal class CommandNotFoundCommand : ICommand
    {
        public CommandResult Execute()
        {
            return new CommandResult();
        }

        public string[] Parameters { get; set; }

        public void BuildPropertiesFromParameters()
        {
            throw new NotImplementedException();
        }
    }
}