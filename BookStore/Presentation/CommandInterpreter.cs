using BookStore.Core.Core.Interfaces;
using Microsoft.Practices.Unity;

namespace BookStore.Presentation
{
    internal class CommandInterpreter : ICommandInterpreter
    {
        private const string WELCOME_MESSAGE = "Welcome to Fisher Books -- Books that hook you line and sinker!";

        [Dependency]
        public ICommandFactory CommandFactory { get; set; }

        [Dependency]
        public ICommandParser CommandParser { get; set; }

        public string GetWelcomeMessage()
        {
            return WELCOME_MESSAGE;
        }

        public string Execute(string commandToExecute)
        {
            var commandArray = CommandParser.Parse(commandToExecute);

            var builtCommand = CommandFactory.BuildCommand(commandArray);

            var result = builtCommand.Execute();

            if (result == null) return "Unknown Error";
            return $"Error - {result.Message}";
        }
    }
}