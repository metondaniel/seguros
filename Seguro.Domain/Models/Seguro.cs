using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Models
{
    public class Seguro
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public int SeguradoId { get; set; }
        public Segurado Segurado { get; set; }

        public decimal ValorSeguro { get; set; }
    }
}
