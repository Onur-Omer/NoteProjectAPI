using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class GroupNoteValidator : AbstractValidator<GroupNote>
    {
        public GroupNoteValidator()
        {
            RuleFor(g => g.Note).NotEmpty();
            RuleFor(g => g.NoteTitle).NotEmpty();
            RuleFor(g => g.Note).MaximumLength(500);
            RuleFor(g => g.NoteTitle).MaximumLength(50);

        }
    }
}
