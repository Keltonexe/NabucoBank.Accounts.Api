namespace NabucoBank.Accounts.Application.ViewModels
{
    public class AddressViewModel
    {
        public long UserId { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
    }
}
