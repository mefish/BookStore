using BookStore.Core.Core.Interfaces;
using BookStore.Domain;
using BookStore.Infrastructure;
using BookStore.Presentation;
using Microsoft.Practices.Unity;

namespace BookStore
{
    internal class Configuration
    {
        private static UnityContainer _unityContainer;

        public static UnityContainer UnityContainer
        {
            get
            {
                if (_unityContainer != null) return _unityContainer;

                _unityContainer = new UnityContainer();

                RegisterTypes();

                return _unityContainer;
            }
        }

        private static void RegisterTypes()
        {
            _unityContainer.RegisterType<ICommandInterpreter, CommandInterpreter>();
            _unityContainer.RegisterType<ICommandPresenterFactory, CommandPresenterFactory>();
            _unityContainer.RegisterType<ICommandParser, CommandParser>();
            _unityContainer.RegisterInstance(typeof(IBookInventory), new BookStoreInventory());
        }
    }
}