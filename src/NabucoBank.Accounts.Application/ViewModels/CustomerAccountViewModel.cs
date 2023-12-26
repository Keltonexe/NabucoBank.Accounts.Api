namespace NabucoBank.Accounts.Application.ViewModels
{
    public class CustomerAccountViewModel
    {
        public string Number { get; set; }
        public string Branch { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public CustomerViewModel Customer {  get; set; }
    }
}
