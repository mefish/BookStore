using System.Text.RegularExpressions;
using BookStore.Core.Core.Interfaces;

namespace BookStore.Presentation
{
    internal class CommandParser : ICommandParser
    {
        public string[] Parse(string commandToParse)
        {
            var stringArray = Regex.Split(commandToParse, "(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            return stringArray;
        }
    }
}