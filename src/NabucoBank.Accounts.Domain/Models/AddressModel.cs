namespace NabucoBank.Accounts.Domain.Models
{
    public class AddressModel : BaseModel
    {
        public string Zipcode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
    }
}
