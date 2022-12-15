using BookPublisher.Domain.Constants;
using BookPublisher.Domain.Models;
using FluentValidation;

namespace BookPublisher.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty().WithMessage(VALIDATORS.MESSAGE_NAME_EMPTY)
                .NotNull().WithMessage(VALIDATORS.MESSAGE_NAME_NULL);
            
            RuleFor(model => model.Email)
                .NotEmpty().WithMessage(VALIDATORS.MESSAGE_EMAIL_EMPTY)
                .NotNull().WithMessage(VALIDATORS.MESSAGE_EMAIL_NULL)
                .EmailAddress().WithMessage(VALIDATORS.MESSAGE_INVALID_EMAIL);
            
            RuleFor(model => model.Password)
                .NotEmpty().WithMessage(VALIDATORS.MESSAGE_PASSWORD_EMPTY)
                .NotNull().WithMessage(VALIDATORS.MESSAGE_PASSWORD_NULL);
            
            RuleFor(model => model.UserType)
                .NotEmpty().WithMessage(VALIDATORS.MESSAGE_TYPE_EMPTY)
                .NotNull().WithMessage(VALIDATORS.MESSAGE_TYPE_NULL);
        }
    }
}
