using AutoFixture.Idioms;
using Endava.TechCourse.BankApp.Application.Queries.GetWallets;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Endava.TechCourse.BankApp.Server.Controllers;
using Endava.TechCourse.BankApp.Tests.Common;
using FluentAssertions;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Tests
{
    public class WalletControllerTests
    {
        [Test]
        [ApplicationData]
        public void CanCreateInstance(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(WalletsController).GetConstructors());
        }

    }
}
