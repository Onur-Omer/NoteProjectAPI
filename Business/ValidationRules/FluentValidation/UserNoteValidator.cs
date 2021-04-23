using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserNoteValidator : AbstractValidator<UserNote>
    {
        public UserNoteValidator()
        {
            RuleFor(u => u.Note).NotEmpty();
            RuleFor(u => u.NoteTitle).NotEmpty();
            RuleFor(u => u.Note).MaximumLength(500);
            RuleFor(u => u.NoteTitle).MaximumLength(50);

        }
    }
}
