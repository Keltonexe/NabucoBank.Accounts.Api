using Dapper.FluentMap.Mapping;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.CrossCutting.FluentMap
{
    public class BankMap : EntityMap<BankModel>
    {
        public BankMap() 
        {
            Map(m => m.Id).ToColumn("ID");
            Map(m => m.Name).ToColumn("NAME");
            Map(m => m.Code).ToColumn("CODE");
            Map(m => m.CreatedAt).ToColumn("DT_CREATED");
            Map(m => m.UpdatedAt).ToColumn("DT_UPDATED");
            Map(m => m.HashCode).ToColumn("HASH_CODE");
        }
    }
}
