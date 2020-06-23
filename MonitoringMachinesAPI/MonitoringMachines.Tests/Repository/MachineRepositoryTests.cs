using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;

namespace MonitoringMachinesAPI.Infra.Data.Repository
{
    [TestFixture]
    public class MachineRepositoryTests
    {
        private IMachineRepository _machineRepository;

        [SetUp]
        public void SetUp()
        {
            _machineRepository = Substitute.For<IMachineRepository>();
        }

        [Test]
        public void Should_Toggle_Machines_Status()
        {
            //TODO

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(0);
                Assert.IsTrue(true);
            });
        }
    }
}
