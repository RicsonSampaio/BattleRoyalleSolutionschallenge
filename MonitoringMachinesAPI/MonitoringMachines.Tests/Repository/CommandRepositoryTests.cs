using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using MonitoringMachinesAPI.Domain.Models;
using MonitoringMachinesAPI.Infra.Data.Context;
using MonitoringMachinesAPI.Infra.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;

namespace Easynvest.Orders.Fixedincome.Test.Application.Query.Handlers
{
    [TestFixture]
    public class CommandRepositoryTests
    {
        private ICommandRepository _commandRepository;

        [SetUp]
        public void SetUp()
        {
            _commandRepository = new CommandRepository();
        }

        [Test]
        public void Should_Return_Valid_CommandResult_When_Valid_CMD_Command()
        {
            var command = new Command { CMDCommand = "ping www.google.com", MachineId = 1 };
            var commandResult = _commandRepository.ExecuteCommand(command);
            
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(commandResult);
                StringAssert.Contains("Pinging www.google.com", commandResult);
            });
        }

        // TODO
        [Test]
        public void Should_Return_Empty_When_Invalid_CMD_Command()
        {
            var command = new Command { CMDCommand = "teste", MachineId = 1 };
            var commandResult = _commandRepository.ExecuteCommand(command);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(commandResult);
                StringAssert.Contains("teste", commandResult);
            });
        }
    }
}
