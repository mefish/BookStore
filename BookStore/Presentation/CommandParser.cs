using BookStore.Core.Core.Interfaces;

namespace BookStore.Presentation
{
    internal class CommandParser : ICommandParser
    {
        public string[] Parse(string commandToParse)
        {
            return commandToParse.Split(null);
        }
    }
}