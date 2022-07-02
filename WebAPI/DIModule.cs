using Autofac;
using Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class DIModule : Autofac.Module
    {
        string connectionString = @"Server=35.193.52.85;Database=Ciudad-Dolar;user=sqlserver;password=R3st@I12022*";

        protected override void Load(ContainerBuilder builder)
        {
            SqlConnection conn;
            #region Lugares Visitados
            builder.RegisterType<CalculoClienteService>().As<ICalculosCliente>().SingleInstance();
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            builder.RegisterInstance<IDbConnection>(conn);
            #endregion
        }
    }
}
