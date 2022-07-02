using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICalcularIVA
    {
        double calcularIVA(System.Data.IDbConnection dbConnection, int id_cliente);
    }

    public interface ICalcularISR
    {
        double calcularISR(System.Data.IDbConnection dbConnection, int id_cliente);
    }

    public interface ICalcularAhorro
    {
        double calcularAhorro(System.Data.IDbConnection dbConnection, int id_cliente);
    }

    public interface IDescuentosCliente : ICalcularIVA, ICalcularISR, ICalcularAhorro
    {

    }
}
