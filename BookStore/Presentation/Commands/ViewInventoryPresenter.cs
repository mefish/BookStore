using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Core.Interfaces;
using BookStore.Core.Core.Models;

namespace BookStore.Presentation.Commands
{
    class ViewInventoryPresenter : IPresenter
    {
        public string[] Parameters { get; set; }

        public void BuildPropertiesFromParameters()
        {
            throw new NotImplementedException();
        }

        public CommandResult ExecuteCommand()
        {
            throw new NotImplementedException();
        }
    }
}
