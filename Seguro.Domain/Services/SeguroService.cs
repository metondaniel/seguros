using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Services
{
    public class SeguroService
    {
        private const decimal MARGEM_SEGURANCA = 0.03m;
        private const decimal LUCRO = 0.05m;

        public decimal CalcularValorSeguro(decimal valorVeiculo)
        {
            var taxaRisco = (valorVeiculo * 5) / (2 * valorVeiculo);
            taxaRisco = taxaRisco / 100; 

            var premioRisco = taxaRisco * valorVeiculo;

            var premioPuro = premioRisco * (1 + MARGEM_SEGURANCA);

            var premioComercial = premioPuro * (1 + LUCRO);

            return Math.Round(premioComercial, 2);
        }
    }
}
