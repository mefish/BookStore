using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;

namespace BookStore.Domain.Commands
{
    internal class StockBookCommand : ICommand
    {
        public StockBookCommand(ICommandFactory commandFactory)
        {
            BookInventory = commandFactory.BookInventory;
        }

        public string ISBN { get; set; }

        public IBookInventory BookInventory { get; set; }

        public CommandResult Execute()
        {
            var bookToAdd = new Book
                            {
                                ISBN = ISBN
                            };

            BookInventory.AddToInventory(bookToAdd);

            return new CommandResult();
        }

        public string[] Parameters { get; set; }

        public void BuildPropertiesFromParameters()
        {
            ISBN = Parameters[0];
        }
    }
}