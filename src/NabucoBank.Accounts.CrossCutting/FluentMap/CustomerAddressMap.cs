using Dapper.FluentMap.Mapping;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.CrossCutting.FluentMap
{
    public class CustomerAddressMap : EntityMap<CustomerAddressModel>
    {
        public CustomerAddressMap() 
        {
            Map(m => m.CustomerId).ToColumn("ID_CUSTOMER");
            Map(m => m.AddressId).ToColumn("ID_ADDRESS");
        }
    }
}
