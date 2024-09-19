using Crud.Domain.Commands;
using Crud.Domain.Commands.Seguros;
using Crud.Domain.Handlers.Seguros;
using Crud.Domain.Services;
using Crud.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Crud.Test
{
    public class CreateSeguroCommandHandlerTests
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly CreateSeguroCommandHandler _handler;
        private readonly SeguroService _seguroService;

        public CreateSeguroCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Seguro")
                .Options;

            _dbContext = new ApplicationDbContext(options);
            _seguroService = new SeguroService();
            _handler = new CreateSeguroCommandHandler(_dbContext, _seguroService);
        }

        [Fact]
        public async Task Handle_DeveCriarSeguro_ComDadosValidos()
        {
            // Arrange
            var command = new CreateSeguroCommand
            {
                NomeSegurado = "João Silva",
                CPF = "12345678900",
                Idade = 30,
                MarcaModelo = "Carro XYZ",
                ValorVeiculo = 10000m
            };

            // Act
            var seguroId = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(seguroId > 0);

            var seguro = await _dbContext.Seguros
                .Include(s => s.Segurado)
                .Include(s => s.Veiculo)
                .FirstOrDefaultAsync(s => s.Id == seguroId);

            Assert.NotNull(seguro);
            Assert.Equal(270.38m, seguro.ValorSeguro);
            Assert.Equal("João Silva", seguro.Segurado.Nome);
            Assert.Equal("Carro XYZ", seguro.Veiculo.MarcaModelo);
        }
    }
}
