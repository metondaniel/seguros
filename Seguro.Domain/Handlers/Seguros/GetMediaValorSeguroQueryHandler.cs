using Crud.Domain.Queries;
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
    public class GetMediaValorSeguroQueryHandler : IRequestHandler<GetMediaValorSeguroQuery, decimal>
    {
        private readonly ApplicationDbContext _context;

        public GetMediaValorSeguroQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> Handle(GetMediaValorSeguroQuery request, CancellationToken cancellationToken)
        {
            var media = await _context.Seguros
                .Select(s => (double)s.ValorSeguro)
                .AverageAsync(cancellationToken);
            return (decimal)Math.Round(media, 2);
        }
    }
}
