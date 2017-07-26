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
            for (int i = 0; i < Parameters.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        ISBN = Parameters[i];
                        break;
                    case 1:
                        Title = Parameters[i];
                        break;
                    case 2:
                        Author = Parameters[i];
                    break;
                }
            }
        }

        public CommandResult ExecuteCommand()
        {
            return Execute();
        }

        public string PrintResult()
        {
            ExecuteCommand();

            return $"Successfully added book with ISBN# {ISBN} to inventory!";
        }
    }
}