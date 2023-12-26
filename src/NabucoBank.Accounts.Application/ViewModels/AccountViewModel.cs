namespace NabucoBank.Accounts.Application.ViewModels
{
    public class AccountViewModel
    {
        public string Number { get; set; }
        public string Branch { get; set; }
        public decimal Balance { get; set; }
        public CustomerViewModel Customer { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
