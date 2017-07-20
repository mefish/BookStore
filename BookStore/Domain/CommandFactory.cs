using System.Linq;
using BookStore.Core.Core.Interfaces;
using BookStore.Domain.Commands;
using Microsoft.Practices.Unity;

namespace BookStore.Domain
{
    public class CommandFactory : ICommandFactory
    {
        [Dependency]
        public IBookInventory BookInventory { get; set; }

        public ICommand BuildCommand(string[] commandToBuild)
        {
            ICommand command = new CommandNotFoundCommand();
            if (commandToBuild.Length == 0) return command;
            if (commandToBuild[0] == "stock") command = new StockBookCommand(this);
            command.Parameters = commandToBuild.Skip(1).ToArray();
            return command;
        }
    }
}