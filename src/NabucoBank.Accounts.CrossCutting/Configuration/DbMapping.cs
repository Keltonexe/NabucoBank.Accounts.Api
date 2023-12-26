using Dapper.FluentMap;
using NabucoBank.Accounts.CrossCutting.FluentMap;

namespace NabucoBank.Accounts.CrossCutting.Configuration
{
    public static class DbMapping
    {
        public static void InitializeMapping() => FluentMapper.Initialize(config =>
                                                           {
                                                               config.AddMap(new AccountMap());
                                                               config.AddMap(new AddressMap());
                                                               config.AddMap(new CustomerMap());
                                                               config.AddMap(new BankMap());
                                                               config.AddMap(new CustomerAddressMap());
                                                           });
    }
}
