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
        }
    }