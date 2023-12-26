using Dapper.FluentMap.Mapping;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.CrossCutting.FluentMap
{
    public class AccountMap : EntityMap<AccountModel>
    {
        public AccountMap() 
        {
            Map(m => m.Id).ToColumn("ID");
            Map(m => m.CustomerId).ToColumn("ID_CUSTOMER");
            Map(m => m.AddressId).ToColumn("ID_ADDRESS");
            Map(m => m.Number).ToColumn("NUMBER");
            Map(m => m.Branch).ToColumn("BRANCH");
            Map(m => m.Balance).ToColumn("BALANCE");
            Map(m => m.CreatedAt).ToColumn("DT_CREATED");
            Map(m => m.UpdatedAt).ToColumn("DT_UPDATED");
            Map(m => m.HashCode).ToColumn("HASH_CODE");
        }
    }
}
