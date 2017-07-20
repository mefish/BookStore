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
            if (!IsValid) return new CommandResult();

            var bookToAdd = new Book
                            {
                                ISBN = ISBN
                            };

            BookInventory.AddToInventory(bookToAdd);

            return new CommandResult
                   {
                       WasSuccessful = true,
                       Message = "Book Stocked!"
                   };
        }

        public string[] Parameters { get; set; }

        public bool IsValid { get { return ISBN != null; } }

        public void BuildPropertiesFromParameters()
        {
            ISBN = Parameters[0];
        }
    }
}