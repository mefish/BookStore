using BookStore.Core.Core.Interfaces;

namespace BookStore.Presentation
{
    internal class CommandInterpreter : ICommandInterpreter
    {
        private const string WELCOME_MESSAGE = "Welcome to Fisher Books -- Books that hook you line and sinker!";
        public ICommandFactory CommandFactory { get; set; }
        public ICommandParser CommandParser { get; set; }

        public string GetWelcomeMessage()
        {
            return WELCOME_MESSAGE;
        }

        public string Execute(string commandToExecute)
        {
            var commandArray = CommandParser.Parse(commandToExecute);

            var result = CommandFactory.ExecuteCommand(commandArray);

            return $"Error - {result.Message}";
        }
    }
}