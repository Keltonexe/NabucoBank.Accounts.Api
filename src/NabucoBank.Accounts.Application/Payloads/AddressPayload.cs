namespace NabucoBank.Accounts.Application.Payloads
{
    public class AddressPayload
    {
        public string Zipcode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
    }
}
