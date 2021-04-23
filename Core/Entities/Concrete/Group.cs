namespace Core.Entities.Concrete
{
    public class Group : IEntity
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
