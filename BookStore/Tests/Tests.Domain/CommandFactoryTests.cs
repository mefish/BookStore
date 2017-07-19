using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace BookStore.Tests.Tests.Domain
{
    [TestFixture]
    class CommandFactoryTests
    {
        [Test]
        public void CommandNotFoundReturnsACommandNotFound()
        {
            var commandFactory = new CommandFactory();

            var command = commandFactory.BuildCommand(new string[0]);

            var result = command.Execute();

            Assert.IsFalse(result.WasSuccessful);
        }
    }
}
