using Dapper.FluentMap.Mapping;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.CrossCutting.FluentMap
{
    public class UserMap : EntityMap<UserModel>
    {
        public UserMap() 
        {
            Map(m => m.Id).ToColumn("ID");
            Map(m => m.Cpf).ToColumn("CPF");
            Map(m => m.Name).ToColumn("NAME");
            Map(m => m.Email).ToColumn("EMAIL");
            Map(m => m.Password).ToColumn("PASSWORD");
            Map(m => m.Phone).ToColumn("PHONE");
            Map(m => m.CreatedAt).ToColumn("DT_CREATED");
            Map(m => m.UpdatedAt).ToColumn("DT_UPDATED");
            Map(m => m.DeletedAt).ToColumn("DT_DELETED");
            Map(m => m.HashCode).ToColumn("HASH_CODE");
        }
    }
}
