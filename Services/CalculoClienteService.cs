using Dapper;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CalculoClienteService : ICalculosCliente
    {
        private readonly IDbConnection _dbConnection;
        public CalculoClienteService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public double calcularAhorro(IDbConnection dbConnection, int id_cliente)
        {
            throw new NotImplementedException();
        }

        public List<Calculo_Cliente> calcularISR(IDbConnection dbConnection, int id_cliente)
        {
            var cliente = dbConnection.Query<InfoCliente>("SELECT * FROM [VW_IMPUESTO_CLIENTE] WHERE id_cliente = " + id_cliente);
            double ISR;

            foreach (var item in cliente)
            {
                var salario = item.Salario;

                if (salario <= 30000.00)
                {
                    ISR = salario * 0.05;
                }
                else
                {
                    ISR = salario * 0.07;
                }

                dbConnection.Query<Calculo_Cliente>("INSERT INTO Calculo_Cliente (id_cliente, id_rubro, Impuesto, Descripcion, Total) VALUES (" 
                                                    + item.id_cliente + "," + item.id_rubro + "," + "'ISR'" + "," + "'Calculo de ISR'" + "," + ISR + ")");
            }

            return (List<Calculo_Cliente>)dbConnection.Query<Calculo_Cliente>("SELECT * FROM  Calculo_Cliente WHERE id_cliente = " + id_cliente);
        }

        public List<Calculo_Cliente> calcularIVA(IDbConnection dbConnection, int id_cliente)
        {
            var cliente = dbConnection.Query<InfoCliente>("SELECT * FROM [VW_IMPUESTO_CLIENTE] WHERE id_cliente = " + id_cliente);
            double IVA;

            foreach (var item in cliente)
            {
                var salario = item.Salario;

                IVA = salario * 0.12;

                dbConnection.Query<Calculo_Cliente>("INSERT INTO Calculo_Cliente (id_cliente, id_rubro, Impuesto, Descripcion, Total) VALUES ("
                                                    + item.id_cliente + "," + item.id_rubro + "," + "'IVA'" + "," + "'Calculo de IVA'" + "," + IVA + ")");
            }

            return (List<Calculo_Cliente>)dbConnection.Query<Calculo_Cliente>("SELECT * FROM  Calculo_Cliente WHERE id_cliente = " + id_cliente);
        }

        public List<Calculo_Cliente> GetCalculosClientes(IDbConnection dbConnection)
        {
            return (List<Calculo_Cliente>)dbConnection.Query<Calculo_Cliente>("SELECT * FROM Calculo_Cliente");
        }

        public List<InfoCliente> GetCliente(IDbConnection dbConnection)
        {
            return (List<InfoCliente>)dbConnection.Query<InfoCliente>("SELECT * FROM [VW_IMPUESTO_CLIENTE]");
        }

        public List<Calculo_Cliente> SaveCalculo(IDbConnection dbConnection, Calculo_Cliente calculo_Cliente)
        {
            throw new NotImplementedException();
        }
    }
}
