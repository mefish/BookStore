using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using Microsoft.Practices.Unity;

namespace BookStore.Domain.Commands
{
    internal class StockBookCommand : ICommand
    {
        public string ISBN;
        //        public CommandResult Execute(string commandParameters)
        //        {
        //            if (commandParameters == string.Empty) return new CommandResult();
        //
        //            var bookToAdd = new Book
        //                            {
        //                                ISBN = "123"
        //                            };
        //
        //            BookInventory.AddToInventory(bookToAdd);
        //
        //            return new CommandResult();
        //        }

        public IBookInventory BookInventory { get; set; }

        public CommandResult Execute()
        {
            var bookToAdd = new Book
                            {
                                ISBN = ISBN
                            };

//            BookInventory.AddToInventory(bookToAdd);

            return new CommandResult();
        }

        public string[] Parameters { get; set; }

        public void BuildPropertiesFromParameters()
        {
            ISBN = Parameters[0];
        }
    }
}