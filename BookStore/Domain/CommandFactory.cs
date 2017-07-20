using System.Linq;
using BookStore.Core.Core.Interfaces;
using BookStore.Domain.Commands;
using BookStore.Presentation.Commands;
using Microsoft.Practices.Unity;

namespace BookStore.Domain
{
    public class CommandPresenterPresenterFactory : ICommandPresenterFactory
    {
        [Dependency]
        public IBookInventory BookInventory { get; set; }

        public IPresenter BuildPresnter(string[] commandToBuild)
        {
            IPresenter presenter = new CommandNotFoundCommand();
            if (commandToBuild.Length == 0) return presenter;
            if (commandToBuild[0] == "stock") presenter = new StockBookPresenter(this);
            presenter.Parameters = commandToBuild.Skip(1).ToArray();
            return presenter;
        }
    }
}