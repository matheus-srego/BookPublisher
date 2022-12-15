using BookPublisher.Domain.Constants;
using BookPublisher.Domain.Models;
using FluentValidation;

namespace BookPublisher.Service.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty().WithMessage(Validators.MESSAGE_NAME_EMPTY)
                .NotNull().WithMessage(Validators.MESSAGE_NAME_NULL);
            
            RuleFor(model => model.Email)
                .NotEmpty().WithMessage(Validators.MESSAGE_EMAIL_EMPTY)
                .NotNull().WithMessage(Validators.MESSAGE_EMAIL_NULL)
                .EmailAddress().WithMessage(Validators.MESSAGE_INVALID_EMAIL);
            
            RuleFor(model => model.Password)
                .NotEmpty().WithMessage(Validators.MESSAGE_PASSWORD_EMPTY)
                .NotNull().WithMessage(Validators.MESSAGE_PASSWORD_NULL);
            
            RuleFor(model => model.UserType)
                .NotEmpty().WithMessage(Validators.MESSAGE_TYPE_EMPTY)
                .NotNull().WithMessage(Validators.MESSAGE_TYPE_NULL);
        }
    }
}