using FluentValidation;
using Identity.Core.DTOs;

namespace Identity.Validation.Avatar
{
    public class AvatarFormValidator : AbstractValidator<AvatarFormDTO>
    {
        public AvatarFormValidator()
        {
            RuleFor(avatar => avatar.Image).NotNull().WithMessage("image is a required field");
        }
    }
}
