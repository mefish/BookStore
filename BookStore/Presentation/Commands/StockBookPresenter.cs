using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;
using BookStore.Domain.Commands;

namespace BookStore.Presentation.Commands
{
    internal class StockBookPresenter : StockBookCommand, IPresenter
    {
        public StockBookPresenter(ICommandPresenterFactory commandPresenterFactory)
            : base(commandPresenterFactory) { }

        public string[] Parameters { get; set; }

        public void BuildPropertiesFromParameters()
        {
            ISBN = Parameters[0];
        }

        public CommandResult ExecuteCommand()
        {
            return Execute();
        }
    }
}