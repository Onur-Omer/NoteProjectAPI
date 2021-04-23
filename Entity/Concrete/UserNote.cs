using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{

    public class UserNote : IEntity
    {
        public int UserId { get; set; }
        [Key]
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string Note { get; set; }
    }
}
