using System;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;

namespace BookStore.Domain.Commands
{
    internal class CommandNotFoundCommand : IPresenter
    {
        public CommandResult Execute()
        {
            return new CommandResult();
        }

        public string[] Parameters { get; set; }

        public bool IsValid { get; }

        public void BuildPropertiesFromParameters()
        {
            throw new NotImplementedException();
        }

        public CommandResult ExecuteCommand()
        {
            return new CommandResult
                   {
                       Message = "Command not found"
                   };
        }
    }
}