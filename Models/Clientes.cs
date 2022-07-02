using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Clientes
    {
        public int id_cliente { get; set; }
        public int CUI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public float Salario { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
        public int id_Pais { get; set; }
        public int id_rubro { get; set; }
    }
}
