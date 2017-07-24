using System.Linq;
using BookStore.Core.Core.Interfaces;
using BookStore.Domain.Commands;
using BookStore.Presentation.Commands;
using Microsoft.Practices.Unity;

namespace BookStore.Presentation
{
    public class CommandPresenterFactory : ICommandPresenterFactory
    {
        [Dependency]
        public IBookInventory BookInventory { get; set; }

        public IPresenter BuildPresnter(string[] commandToBuild)
        {
            IPresenter presenter = new CommandNotFoundCommand();

            if (commandToBuild.Length == 0) return presenter;

            switch (commandToBuild[0])
            {
                case "stock":
                    presenter = new StockBookPresenter(this);
                    break;
                case "inventory":
                    presenter = new ViewInventoryPresenter();
                break;
            }

            presenter.Parameters = commandToBuild.Skip(1).ToArray();

            return presenter;
        }
    }
}