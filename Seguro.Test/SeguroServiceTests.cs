using Crud.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Seguro.Test
{
    public class SeguroServiceTests
    {
        private readonly SeguroService _seguroService;

        public SeguroServiceTests()
        {
            _seguroService = new SeguroService();
        }

        [Fact]
        public void CalcularValorSeguro_DeveRetornarValorCorreto()
        {
            // Arrange
            decimal valorVeiculo = 10000m;

            // Act
            var valorSeguro = _seguroService.CalcularValorSeguro(valorVeiculo);

            // Assert
            Assert.Equal(270.38m, valorSeguro);
        }
    }
}
