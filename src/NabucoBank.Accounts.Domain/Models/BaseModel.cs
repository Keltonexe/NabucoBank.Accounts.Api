namespace NabucoBank.Accounts.Domain.Models
{
    public class BaseModel
    {
        public long Id { get; set; }
        public DateTime _createdAt;
        public DateTime CreatedAt
        {
            get { return _createdAt == default ? DateTime.Now : _createdAt; }
            set { _createdAt = value; }
        }
        public DateTime? UpdatedAt { get; set; }
        public string HashCode { get; set; }
    }
}
