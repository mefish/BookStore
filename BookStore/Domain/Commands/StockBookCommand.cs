using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;

namespace BookStore.Domain.Commands
{
    internal class StockBookCommand : ICommand
    {
        public StockBookCommand(ICommandPresenterFactory commandPresenterFactory)
        {
            BookInventory = commandPresenterFactory.BookInventory;
        }

        public string ISBN { get; set; }

        public IBookInventory BookInventory { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }

        public bool IsValid => ISBN != null;

        public CommandResult Execute()
        {
            if (!IsValid) return new CommandResult();

            var bookToAdd = new Book
                            {
                                ISBN = ISBN,
                                Title = Title,
                                Author = Author
                            };

            BookInventory.AddToInventory(bookToAdd);

            return new CommandResult
                   {
                       WasSuccessful = true,
                       Message = "Book Stocked!"
                   };
        }
    }
}