using API_4BIO.Models.Request;
using FastEndpoints;
using FluentValidation;

namespace API_4BIO.BusinessLogic.Validators
{
    public class UpdateClientValidator : Validator<UpdateClientRequest>
    {
        public UpdateClientValidator()
        {
            RuleFor(c => c.Client.ClientId)
                .NotEmpty()
                .WithMessage("É necessário especificar o ID do cliente que se deseja editar!");
            RuleFor(c => c.Client)
                .NotNull()
                .NotEmpty()
                .WithMessage("Objeto de cliente não pode estar vazio!");

            RuleFor(c => c.Client.FullName)
                .NotEmpty()
                .WithMessage("Nome não pode estar vazio!")
                .MinimumLength(2)
                .WithMessage("O nome deve conter ao menos 2 caracteres!");

            RuleFor(c => c.Client.CPF)
               .NotEmpty()
               .WithMessage("CPF não pode estar vazio!")
               .Matches("([0-9]{2}[\\.]?[0-9]{3}[\\.]?[0-9]{3}[\\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\\.]?[0-9]{3}[\\.]?[0-9]{3}[-]?[0-9]{2})")
               .WithMessage("Formato Incorreto de CPF");

            RuleFor(c => c.Client.RG)
              .NotEmpty()
              .WithMessage("RG não pode estar vazio!")
              .Matches("(^\\d{1,2}).?(\\d{3}).?(\\d{3})-?(\\d{1}|X|x$)")
              .WithMessage("Formato Incorreto de RG");

            RuleFor(c => c.Client.Address.PostalCode)
                .NotEmpty()
                .WithMessage("CEP não pode estar vazio");

            RuleFor(c => c.Client.Address.State)
              .NotEmpty()
              .WithMessage("Estado não pode estar vazio");

            RuleFor(c => c.Client.Address.Number)
                .NotEmpty()
                .WithMessage("Número do logradouro não pode estar vazio!");

            RuleFor(c => c.Client.Address.StreetName)
                .MaximumLength(5)
                .WithMessage("Nome do logradouro deve conter ao menos 5 caracteres")
                .NotEmpty()
                .WithMessage("Nome do logradouro não pode estar vazio!");

            RuleFor(c => c.Client.Address.Country)
                .NotEmpty()
                .WithMessage("Nome do País não pode estar vazio!");

            RuleFor(c => c.Client.Address.Reference)
                .NotEmpty()
                .WithSeverity(Severity.Warning)
                .WithMessage("Ponto de referência vazio.");

            RuleFor(c => c.Client.Address.Complement)
                .NotEmpty()
                .WithSeverity(Severity.Warning)
                .WithMessage("Complemento vazio.");

        }
    }
}
