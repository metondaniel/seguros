using Crud.Domain.Commands.Seguros;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Validators
{
    public class CreatePersonCommandValidator : AbstractValidator<CreateSeguroCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(x => x.CPF).NotEmpty().WithMessage("Cpf é obrigatório.");
            RuleFor(x => x.ValorVeiculo).GreaterThan(0).WithMessage("Valor tem que ser maior que 0.");
        }
    }
}
