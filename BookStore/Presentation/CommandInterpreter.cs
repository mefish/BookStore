namespace BookStore.Presentation
{
    internal class CommandInterpreter
    {
        private const string WELCOME_MESSAGE = "Welcome to Fisher Books -- Books that hook you line and sinker!";

        //        public static string Execute(string command)
        //        {
        //            var result =  new StockBookCommand().Execute();
        //            return result.WasSuccessful.ToString();
        //        }
        public string GetWelcomeMessage()
        {
            return WELCOME_MESSAGE;
        }
    }
}