namespace NabucoBank.Accounts.Application.Payloads
{
    public class AccountPayload
    {
        public long UserId { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
    }
}
