using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DTO.Validators
{
    public class RegisterBossDtoValidator : AbstractValidator<RegisterBossDTO>
    {
        public RegisterBossDtoValidator(DbEmployeeManagementContext dbContext)
        {
            RuleFor(x => x.UserName)
                .NotEmpty();

            RuleFor(x => x.Email)
                 .NotEmpty()
                 .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(6);

            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();

            RuleFor(x => x.DateOfBirth)
                .NotEmpty();

            RuleFor(x => x.CompanyName)
                .NotEmpty();

            RuleFor(x => x.NIP)
                .NotEmpty();

            RuleFor(x => x.Code)
                .NotEmpty();

            RuleFor(x => x.UserName)
                .Custom((value, context) =>
                {
                    var UserNameInUse = dbContext.Users.Any(u => u.UserName == value);
                    if(UserNameInUse)
                    {
                        context.AddFailure("UserName", "That username is taken");
                    }
                });

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var EmailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (EmailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
}
