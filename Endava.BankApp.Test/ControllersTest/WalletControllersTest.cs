using AutoFixture.Idioms;
using Endava.BankApp.Test.Common;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Endava.TechCourse.BankApp.Server.Controllers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Endava.BankApp.Test.ControllersTest
{
    public class WalletControllersTest
    {
        [Test, ApplicationData]
        public async Task ShouldGetWallets([Frozen] ApplicationDbContext context,[Greedy] WalletController controller,
                                           Wallet firstWallet, Wallet secondWallet )
            //Frozen in order to have the same database in the controller and in the database
            //Any controller of type base controller has a base class, so we have to use our own constructor(with the most parameters)
        {

            context.Wallets.AddRange(firstWallet, secondWallet);
            context.SaveChanges();  
            context.ChangeTracker.Clear();
            var result = await controller.GetWallets();
            result.Count.Should().Be(2);
        }

      [Test, ApplicationData]

        public void CanCreateInstance(GuardClauseAssertion assertion)

            => assertion.Verify(typeof(WalletController).GetConstructors());
    }
}
