namespace NabucoBank.Accounts.Application.Payloads
{
    public class CustomerPayload
    {
        public string Document { get; set; }
        public decimal Income { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
