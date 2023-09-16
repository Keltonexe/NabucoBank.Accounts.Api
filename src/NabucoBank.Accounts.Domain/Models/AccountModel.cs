namespace NabucoBank.Accounts.Domain.Models
{
    public class AccountModel : BaseModel
    {
        public long UserId { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
    }
}
