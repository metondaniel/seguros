using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string MarcaModelo { get; set; }
        public decimal ValorVeiculo { get; set; }
    }
}
