using System;
using BookStore.Core.Core.Interfaces;
using BookStore.Presentation;
using Microsoft.Practices.Unity;

namespace BookStore
{
    internal class Program
    {
        private const string READ_PROMPT = "> ";
        private static UnityContainer _unityContainer;
        private static ICommandInterpreter _commandInterpreter;

        private static void Main(string[] args)
        {
            Console.Title = typeof(Program).Name;

            RegisterTypes();

            Run();
        }

        private static void RegisterTypes()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterType<ICommandInterpreter, CommandInterpreter>();
        }

        private static void Run()
        {
            _commandInterpreter = _unityContainer.Resolve<ICommandInterpreter>();

            Console.WriteLine(_commandInterpreter.GetWelcomeMessage());

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