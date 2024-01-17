namespace NabucoBank.Accounts.Application.ViewModels
{
    public class CustomerAccountViewModel
    {
        public string AccountNumber { get; set; }
        public string AccountBranch { get; set; }
        public string AccountType { get; set; }
        public decimal AccountBalance { get; set; }
        public CustomerViewModel Customer {  get; set; }
    }
}
