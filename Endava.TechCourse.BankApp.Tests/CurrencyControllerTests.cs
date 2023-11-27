using Endava.TechCourse.BankApp.Application.Commands;
using Endava.TechCourse.BankApp.Application.Commands.AddCurrency;
using Endava.TechCourse.BankApp.Server.Controllers;
using Endava.TechCourse.BankApp.Shared;
using Endava.TechCourse.BankApp.Tests.Common;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Tests
{
    public class CurrencyControllerTests
    {
        [Test, ApplicationData]
        public async Task ShouldAddCurrency([Frozen] IMediator mediator, [Greedy] CurrencyController controller, CurrencyDto currencyDto)
        {
            var expectedCommand = new AddCurrencyCommand()
            {
                Name = currencyDto.Name,
                CurrencyCode = currencyDto.CurrencyCode,
                ChangeRate = currencyDto.ChangeRate
            };

            mediator.Send(Arg.Any<AddCurrencyCommand>()).Returns(new CommandStatus());


            await controller.AddCurrency(currencyDto);
            await mediator.Received(1).Send(Arg.Is<AddCurrencyCommand>(X=>X.Name == currencyDto.Name &&
            X.CurrencyCode == currencyDto.CurrencyCode
                && X.ChangeRate == currencyDto.ChangeRate));
        }
    }
}
