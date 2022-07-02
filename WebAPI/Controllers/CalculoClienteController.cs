using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoClienteController : ControllerBase
    {
        private readonly ICalculosCliente _service;
        private readonly IDbConnection _dbConnection;
        public CalculoClienteController(ICalculosCliente cliente, IDbConnection dbConnection)
        {
            this._service = cliente;
            this._dbConnection = dbConnection;
        }
        // GET: api/<CalculoClienteController>
        [HttpGet]
        public List<InfoCliente> Get()
        {
            return _service.GetCliente(_dbConnection);
        }

        // POST api/<CalculoClienteController>
        [HttpPost("CalculoISR")]
        public List<Calculo_Cliente> Post(int id_cliente)
        {
            return _service.calcularISR(_dbConnection, id_cliente);
        }

        [HttpPost("CalculoIVA")]
        public List<Calculo_Cliente> PostIVA(int id_cliente)
        {
            return _service.calcularIVA(_dbConnection, id_cliente);
        }

        [HttpGet("CalculosClientes")]
        public List<Calculo_Cliente> GetCals()
        {
            return _service.GetCalculosClientes(_dbConnection);
        }
    }
}
