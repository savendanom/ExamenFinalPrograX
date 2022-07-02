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
        List<Calculo_Cliente> calcularIVA(System.Data.IDbConnection dbConnection, int id_cliente);
    }

    public interface ICalcularISR
    {
        List<Calculo_Cliente> calcularISR(System.Data.IDbConnection dbConnection, int id_cliente);
    }

    public interface ICalcularAhorro
    {
        double calcularAhorro(System.Data.IDbConnection dbConnection, int id_cliente);
    }
    public interface ICalcCliente
    {
        List<InfoCliente> GetCliente(System.Data.IDbConnection dbConnection);
        List<Calculo_Cliente> GetCalculosClientes(System.Data.IDbConnection dbConnection);
        List<Calculo_Cliente> SaveCalculo(System.Data.IDbConnection dbConnection, Calculo_Cliente calculo_Cliente);
    }

    public interface ICalculosCliente : ICalcularIVA, ICalcularISR, ICalcularAhorro, ICalcCliente
    {

    }
}
