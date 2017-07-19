using System;
using BookStore.Presentation;

namespace BookStore
{
    internal class Program
    {
        private const string READ_PROMPT = "console> ";

        private static void Main(string[] args)
        {
            Console.Title = typeof(Program).Name;

            Run();
        }

        private static void Run()
        {
            var commandInterpreter = new CommandInterpreter();

            Console.WriteLine(commandInterpreter.GetWelcomeMessage());

            while (true)
            {
                var consoleInput = ReadFromConsole();
                if (string.IsNullOrWhiteSpace(consoleInput)) continue;

                try
                {
                    var result = Execute(consoleInput);

                    WriteToConsole(result);
                }
                catch (Exception exception)
                {
                    WriteToConsole(exception.Message);
                }
            }
        }

        private static string ReadFromConsole(string promptMessage = "")
        {
            Console.Write(READ_PROMPT + promptMessage);
            return Console.ReadLine();
        }

        private static void WriteToConsole(string message = "")
        {
            if (message.Length > 0) Console.WriteLine(message);
        }

        private static string Execute(string command)
        {
            //            return CommandInterpreter.Execute(command);
            return command;
        }

        public void DisplayToUser(string stringToDisplay)
        {
            Console.WriteLine(stringToDisplay);
        }
    }
}