using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class InfoCliente
    {
        public int id_cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double Salario { get; set; }
        public string Rubro { get; set; }
        public double Porcentaje { get; set; }
        public int id_rubro { get; set; }
    }
}
