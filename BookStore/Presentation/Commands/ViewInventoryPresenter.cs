using System;
using System.Linq;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using BookStore.Domain.Commands;

namespace BookStore.Presentation.Commands
{
    internal class ViewInventoryPresenter : ViewInventoryCommand, IPresenter
    {
        public ViewInventoryPresenter(ICommandPresenterFactory presenterFactory)
            : base(presenterFactory) { }

        public string[] Parameters { get; set; }

        public void BuildPropertiesFromParameters() { }

        public CommandResult ExecuteCommand()
        {
            return Execute();
        }

        public string ViewBookAsString(Book book)
        {
            return $"ISBN: {book.ISBN} Title: {book.Title} Author: {book.Author} Price: ${book.Price}{Environment.NewLine}";
        }

        public string PrintResult()
        {
            Execute();

            var printedResult = InventoryList.Select(ViewBookAsString);

            return string.Concat(printedResult);
        }
    }
}