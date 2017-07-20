using BookStore.Core.Core.Interfaces;
using BookStore.Domain.Commands;

namespace BookStore.Domain
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand BuildCommand(string[] commandToBuild)
        {
            ICommand command = new CommandNotFoundCommand();
            if (commandToBuild.Length == 0) return command;
            if (commandToBuild[0] == "stock") command = new StockBookCommand();
            return command;
        }
    }
}