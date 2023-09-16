namespace NabucoBank.Accounts.Domain.Models
{
    public class UserModel : BaseModel
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
