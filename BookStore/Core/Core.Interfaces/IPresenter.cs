using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Core.Models;

namespace BookStore.Core.Core.Interfaces
{
    public interface IPresenter
    {
        string[] Parameters { get; set; }

        void BuildPropertiesFromParameters();

        CommandResult ExecuteCommand();
    }
}
