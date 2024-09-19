using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Crud.Domain.Commands.Seguros
{
    public class CreateSeguroCommand : IRequest<int>
    {
        public string MarcaModelo { get; set; }
        public decimal ValorVeiculo { get; set; }

        public string NomeSegurado { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
    }
}
