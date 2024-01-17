using FluentValidation;
using NabucoBank.Accounts.Application.Payloads;

namespace NabucoBank.Accounts.Api.Validators
{
    public class AccountValidator : AbstractValidator<AccountPayload>
    {
        public AccountValidator()
        {
            RuleFor(account => account.Customer.Document).NotEmpty().WithMessage("O campo documento é obrigatório.");
            RuleFor(account => account.Customer.Income).NotEmpty().WithMessage("O campo renda é obrigatório.");
            RuleFor(account => account.Customer.Name).NotEmpty().WithMessage("O campo nome é obrigatório.");
            RuleFor(account => account.Customer.Email).NotEmpty().WithMessage("O campo e-mail é obrigatório.");
            RuleFor(account => account.Customer.Phone).NotEmpty().WithMessage("O campo telefone é obrigatório.");
            RuleFor(account => account.Address.Zipcode).NotEmpty().WithMessage("O campo cep é obrigatório.");
            RuleFor(account => account.Address.Street).NotEmpty().WithMessage("O campo rua é obrigatório.");
            RuleFor(account => account.Address.City).NotEmpty().WithMessage("O campo cidade é obrigatório.");
            RuleFor(account => account.Address.State).NotEmpty().WithMessage("O campo estado é obrigatório.");
            RuleFor(account => account.Address.Number).NotEmpty().WithMessage("O campo número é obrigatório.");
            RuleFor(account => account.Address.Complement).NotEmpty().WithMessage("O campo complemento é obrigatório.");
        }
    }
}
