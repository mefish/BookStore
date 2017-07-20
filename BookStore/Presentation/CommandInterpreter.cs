using BookStore.Core.Core.Interfaces;
using Microsoft.Practices.Unity;

namespace BookStore.Presentation
{
    internal class CommandInterpreter : ICommandInterpreter
    {
        private const string WELCOME_MESSAGE = "Welcome to Fisher Books -- Books that hook you line and sinker!";

        [Dependency]
        public ICommandPresenterFactory CommandPresenterFactory { get; set; }

        [Dependency]
        public ICommandParser CommandParser { get; set; }

        public string GetWelcomeMessage()
        {
            return WELCOME_MESSAGE;
        }

        public string Execute(string commandToExecute)
        {
            var commandArray = CommandParser.Parse(commandToExecute);

            var builtCommand = BuildPresenterForCommand(commandArray);

            var result = builtCommand.ExecuteCommand();

            if (result == null) return "Unknown Error";
            if (result.WasSuccessful) return $"Success - {result.Message}";
            return $"Error - {result.Message}";
        }

        private IPresenter BuildPresenterForCommand(string[] commandArray)
        {
            var builtCommand = CommandPresenterFactory.BuildCommand(commandArray);

            builtCommand.BuildPropertiesFromParameters();
            return builtCommand;
        }
    }
}