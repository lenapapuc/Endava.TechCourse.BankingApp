    using Endava.TechCourse.BankApp.Domain.Models;
    using Endava.TechCourse.BankApp.Shared;

    namespace Endava.TechCourse.BankApp.Server.Common
    {
        public static class Mapper
        {
            public static List<WalletDto> Map(IEnumerable<Wallet> wallets)
            {
                var dtos = new List<WalletDto>();
                foreach (var wallet in wallets)
                {
                var dto = new WalletDto()
                    {
                       
                        Id = wallet.Id.ToString(),
                        Type = wallet.Type,
                        Currency = wallet.Currency.Name,
                        ChangeRate = wallet.Currency.ChangeRate,
                        Amount = wallet.Amount,
                        LastNameofUser = wallet.User.LastName,
                        FirstNameofUser = wallet.User.FirstName
                    };

                dtos.Add(dto);
                }

                return dtos;
            }

        public static List<WalletDto> Map1(IEnumerable<Wallet> wallets)
        {
            var dtos = new List<WalletDto>();
            foreach (var wallet in wallets)
            {
                var dto = new WalletDto()
                {

                    Id = wallet.Id.ToString(),
                    Type = wallet.Type,
                    Currency = wallet.Currency.Name,
                    ChangeRate = wallet.Currency.ChangeRate,
                    Amount = wallet.Amount
                };

                dtos.Add(dto);
            }

            return dtos;
        }
        public static WalletDto Map(Wallet wallet)
            {
           
                    var dto = new WalletDto()
                    {
                        Id = wallet.Id.ToString(),
                        Type = wallet.Type,
                        Currency = wallet.Currency.Name,
                        ChangeRate = wallet.Currency.ChangeRate,
                        Amount = wallet.Amount
                       
                    };

                return dto;
            }

            public static List<CurrencyDto> Map(IEnumerable<Currency> currencies)
            {
                var dtos = new List<CurrencyDto>();

                foreach (var currency in currencies)
                {
                    var dto = new CurrencyDto()
                    {
                        Id = currency.Id.ToString(),
                        CurrencyCode = currency.CurrencyCode,
                        ChangeRate = currency.ChangeRate,
                        Name = currency.Name,
         
                    };

                    dtos.Add(dto);
                }

                return dtos;
            }

            public static CurrencyDto Map(Currency currency )
            {
                    var dto = new CurrencyDto()
                    {
                        Id = currency.Id.ToString(),
                        CurrencyCode = currency.CurrencyCode,
                        ChangeRate = currency.ChangeRate,
                        Name = currency.Name,

                    };

                return dto;
            }

        public static List<TransactionDto> Map(IEnumerable<Transaction> transactions)
        {
            var dtos = new List<TransactionDto>();
            foreach (var transaction in transactions)
            {
                var dto = new TransactionDto()
                {
                    Id= transaction.Id.ToString(),
                    Amount = transaction.Amount,
                    Commission  = transaction.Commission,
                    Description = transaction.Description,
                    Type = transaction.Type,
                    SourceWallet = transaction.SourceWallet.Id.ToString(),
                    DestinationWallet = transaction.DestinationWallet.Id.ToString(),
                    SourceUserId = transaction.SourceUser.Id.ToString(),
                    DestinationUserId = transaction.DestinationUser.Id.ToString(),
                    Currency = transaction.Currency.Name,
                    SourceLastName = transaction.SourceUser.LastName,
                    DestinationLastName = transaction.DestinationUser.LastName
                };

                dtos.Add(dto);
            }

            return dtos;
        }
    }
    }