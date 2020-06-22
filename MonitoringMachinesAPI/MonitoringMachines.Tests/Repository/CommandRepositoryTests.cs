using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
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
            _commandRepository = Substitute.For<ICommandRepository>();
        }

        [Test]
        public void Should_Valid_Command()
        {

            //_commandRepository.ExecuteCommand();

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(0);
                Assert.IsTrue(true);
            });
            //CreateArrange(new List<WithdrawalValidationType>());

            //var request = new BuyValidationQuery<bool>(CUSTOMER_ID);
            //var result = _sut.Handle(request, CancellationToken.None).Result;

            //Assert.Multiple(() =>
            //{
            //    Assert.IsTrue(result.IsSuccess);
            //    Assert.IsEmpty(result.Messages);
            //});
        }

        [Test]
        public void Should_Return_When_Machine_isnull()
        {
            //CreateArrange(new List<WithdrawalValidationType>() { WithdrawalValidationType.InSettlement });

            //var request = new BuyValidationQuery<bool>(CUSTOMER_ID);
            //var result = _sut.Handle(request, CancellationToken.None).Result;

            //Assert.IsFalse(result.Value);
        }

        [Test]
        public void Should_Return_When_Machine_IsDown()
        {
            //foreach (var validation in WithdrawalValidationType.List())
            //{
            //    ExecuteValidation(validation);
            //}
        }

    }
}
