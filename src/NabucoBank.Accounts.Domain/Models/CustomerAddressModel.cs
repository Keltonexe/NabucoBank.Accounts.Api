namespace NabucoBank.Accounts.Domain.Models
{
    public class CustomerAddressModel
    {
        public CustomerAddressModel(long customerId, long addressId)
        {
            CustomerId = customerId;
            AddressId = addressId;
        }
        public long CustomerId { get; set; }
        public long AddressId { get; set; }
    }
}
