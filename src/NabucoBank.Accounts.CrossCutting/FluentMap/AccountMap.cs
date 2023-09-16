using Dapper.FluentMap.Mapping;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.CrossCutting.FluentMap
{
    public class AccountMap : EntityMap<AccountModel>
    {
        public AccountMap() 
        {
            Map(m => m.Id).ToColumn("ID");
            Map(m => m.UserId).ToColumn("ID_USER");
            Map(m => m.Number).ToColumn("NUMBER");
            Map(m => m.Balance).ToColumn("BALANCE");
            Map(m => m.CreatedAt).ToColumn("DT_CREATED");
            Map(m => m.UpdatedAt).ToColumn("DT_UPDATED");
            Map(m => m.DeletedAt).ToColumn("DT_DELETED");
            Map(m => m.HashCode).ToColumn("HASH_CODE");
        }
    }
}
