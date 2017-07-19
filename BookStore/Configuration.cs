using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Core.Interfaces;
using BookStore.Presentation;
using Microsoft.Practices.Unity;

namespace BookStore
{
    class Configuration
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
            //            _unityContainer.RegisterType<ICommandFactory, ICommandFactory>();
            _unityContainer.RegisterType<ICommandParser, CommandParser>();
        }
    }
}
