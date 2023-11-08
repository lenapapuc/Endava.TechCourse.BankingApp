using AutoFixture.Idioms;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Endava.TechCourse.BankApp.Server.Controllers;
using Endava.TechCourse.BankApp.Tests.Common;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Tests
{
    public class WalletControllersTest
    {
        [Test]
        [ApplicationData]
        public void CanCreateInstance(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(WalletsController).GetConstructors());
        }

        [Test]
        [ApplicationData]
        public async Task ShouldGetWallets(
            [Frozen] ApplicationDbContext context,
            [Greedy] WalletsController controller
            )
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            //Arrange
            var firstWallet = fixture.Create<Wallet>();
            var secondWallet = fixture.Create<Wallet>();

            context.Wallets.AddRange(firstWallet, secondWallet);
            context.SaveChanges();
            context.ChangeTracker.Clear();

            //Act
            var result = await controller.GetWallets();

            //Assert
            result.Count.Should().Be(2);
        }

    }
}
