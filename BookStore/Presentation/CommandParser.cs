using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Presentation
{
    class CommandParser
    {
        public string[] Parse(string commandToParse)
        {
            return commandToParse.Split(null);
        }
    }
}
