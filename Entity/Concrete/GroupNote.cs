using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{

    public class GroupNote : IEntity
    {
        public int GroupId { get; set; }
        [Key]
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string Note { get; set; }
    }
}
