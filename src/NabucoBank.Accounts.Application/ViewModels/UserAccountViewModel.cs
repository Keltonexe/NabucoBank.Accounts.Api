namespace NabucoBank.Accounts.Application.ViewModels
{
    public class UserAccountViewModel
    {
        public long UserId { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public UserViewModel User {  get; set; }
    }
}
