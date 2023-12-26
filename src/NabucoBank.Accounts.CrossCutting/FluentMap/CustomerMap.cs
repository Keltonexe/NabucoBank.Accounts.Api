using Dapper.FluentMap.Mapping;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.CrossCutting.FluentMap
{
    public class CustomerMap : EntityMap<CustomerModel>
    {
        public CustomerMap() 
        {
            Map(m => m.Id).ToColumn("ID");
            Map(m => m.Document).ToColumn("DOCUMENT");
            Map(m => m.Income).ToColumn("INCOME");
            Map(m => m.Name).ToColumn("NAME");
            Map(m => m.Email).ToColumn("EMAIL");
            Map(m => m.Phone).ToColumn("PHONE");
            Map(m => m.CreatedAt).ToColumn("DT_CREATED");
            Map(m => m.UpdatedAt).ToColumn("DT_UPDATED");
            Map(m => m.HashCode).ToColumn("HASH_CODE");
        }
    }
}
