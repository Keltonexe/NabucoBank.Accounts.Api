namespace NabucoBank.Accounts.Application.Payloads
{
    public class AccountPayload
    {
        public AddressPayload Address { get; set; }
        public CustomerPayload Customer { get; set; }
    }
}
