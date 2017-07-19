using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Core.Interfaces
{
    public interface ICommandInterpreter
    {
        string GetWelcomeMessage();

        string Execute(string commandToExecute);
    }
}
