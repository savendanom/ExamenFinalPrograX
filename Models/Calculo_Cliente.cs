using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Calculo_Cliente
    {
        public int id_calculo { get; set; }
        public int id_cliente { get; set; }
        public int id_rubro { get; set; }
        public string Impuesto { get; set; }
        public string Descripcion { get; set; }
        public double Total { get; set; }
    }
}
