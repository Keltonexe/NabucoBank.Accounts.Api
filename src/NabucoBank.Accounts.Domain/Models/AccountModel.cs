namespace NabucoBank.Accounts.Domain.Models
{
    public class AccountModel : BaseModel
    {
        public AccountModel()
        {

        }
        public AccountModel(long customerId, long addressId)
        {
            CustomerId = customerId;
            AddressId = addressId;
        }
        public AccountModel(long customerId, long addressId, string number, string branch, decimal balance = 0)
        {
            CustomerId = customerId;
            AddressId = addressId;
            Number = number;
            Branch = branch;
            Balance = balance;
        }
        public long CustomerId { get; set; }
        public long AddressId { get; set; }
        public string Number { get; set; }
        public string Branch { get; set; }
        public decimal Balance { get; set; }
    }
}
