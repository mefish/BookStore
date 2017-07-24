using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;

namespace BookStore.Domain.Commands
{
    internal class CommandNotFoundCommand : IPresenter
    {
        public bool IsValid { get; }

        public string[] Parameters { get; set; }

        public void BuildPropertiesFromParameters() { }

        public CommandResult ExecuteCommand()
        {
            return new CommandResult
                   {
                       Message = "Command not found"
                   };
        }

        public CommandResult Execute()
        {
            return new CommandResult();
        }
    }
}