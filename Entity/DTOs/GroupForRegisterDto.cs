using Core.Entities;

namespace Entities.DTOs
{
    public class GroupForRegisterDto : IDto
    {
        public string GroupName { get; set; }
        public string Password { get; set; }
    }
}