using Crud.Domain.Models;
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
    public class GetSeguroByIdQueryHandler : IRequestHandler<GetSeguroByIdQuery, Seguro>
    {
        private readonly ApplicationDbContext _context;

        public GetSeguroByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Seguro> Handle(GetSeguroByIdQuery request, CancellationToken cancellationToken)
        {
            var seguro = await _context.Seguros
                .Include(s => s.Veiculo)
                .Include(s => s.Segurado)
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            return seguro;
        }
    }
}
