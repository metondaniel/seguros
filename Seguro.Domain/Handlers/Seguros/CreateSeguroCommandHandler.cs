using Crud.Domain.Commands.Seguros;
using Crud.Domain.Models;
using Crud.Domain.Services;
using Crud.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Handlers.Seguros
{
    public class CreateSeguroCommandHandler : IRequestHandler<CreateSeguroCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly SeguroService _seguroService;

        public CreateSeguroCommandHandler(ApplicationDbContext context, SeguroService seguroService)
        {
            _context = context;
            _seguroService = seguroService;
        }

        public async Task<int> Handle(CreateSeguroCommand request, CancellationToken cancellationToken)
        {
            var segurado = await _context.Segurados.FirstOrDefaultAsync(s => s.CPF == request.CPF, cancellationToken);
            if (segurado == null)
            {
                segurado = new Segurado
                {
                    Nome = request.NomeSegurado,
                    CPF = request.CPF,
                    Idade = request.Idade
                };
                _context.Segurados.Add(segurado);
                await _context.SaveChangesAsync(cancellationToken);
            }

            var veiculo = new Veiculo
            {
                MarcaModelo = request.MarcaModelo,
                ValorVeiculo = request.ValorVeiculo
            };
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync(cancellationToken);

            var valorSeguro = _seguroService.CalcularValorSeguro(request.ValorVeiculo);

            var seguro = new Seguro
            {
                SeguradoId = segurado.Id,
                VeiculoId = veiculo.Id,
                ValorSeguro = valorSeguro
            };
            _context.Seguros.Add(seguro);
            await _context.SaveChangesAsync(cancellationToken);

            return seguro.Id;
        }
    }
}
