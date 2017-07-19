using BookStore.Core.Core.Interfaces;

namespace BookStore.Presentation
{
    internal class CommandInterpreter
    {
        private const string WELCOME_MESSAGE = "Welcome to Fisher Books -- Books that hook you line and sinker!";
        public ICommandFactory CommandFactory { get; set; }

        public string GetWelcomeMessage()
        {
            return WELCOME_MESSAGE;
        }

        public string Execute(string commandToExecute)
        {
            var result = CommandFactory.ExecuteCommand(commandToExecute);

            return $"Error - {result.Message}";
        }
    }
}