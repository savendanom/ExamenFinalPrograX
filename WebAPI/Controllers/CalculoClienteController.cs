using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Sentry;
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
        private readonly ILogger<CalculoClienteController> _logger;
        public CalculoClienteController(ICalculosCliente cliente, IDbConnection dbConnection, ILogger<CalculoClienteController> logger)
        {
            this._service = cliente;
            this._dbConnection = dbConnection;
            _logger = logger;
        }
        // GET: api/<CalculoClienteController>
        [HttpGet]
        public List<InfoCliente> Get()
        {
            try
            {
                SentrySdk.CaptureMessage("Get Complete ", SentryLevel.Info);
                return _service.GetCliente(_dbConnection);
               
            }
            catch (Exception ex)
            {

                SentrySdk.CaptureException(ex);
                SentrySdk.CaptureMessage("Error en el metodo Get Info Cliente", SentryLevel.Error);
                throw ex;
            }
            
        }
       
        
        // POST api/<CalculoClienteController>
        [HttpPost("CalculoISR")]
        public List<Calculo_Cliente> Post(int id_cliente)
        {
            try
            {
                SentrySdk.CaptureMessage("Post ISR Complete", SentryLevel.Info);
                return _service.calcularISR(_dbConnection, id_cliente);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                SentrySdk.CaptureMessage("Error al calcular el ISR", SentryLevel.Error);
                throw ex;
            }
            
        }

        [HttpPost("CalculoIVA")]
        public List<Calculo_Cliente> PostIVA(int id_cliente)
        {
            try
            {
                SentrySdk.CaptureMessage("Post IVA complete", SentryLevel.Info);
                return _service.calcularIVA(_dbConnection, id_cliente);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                SentrySdk.CaptureMessage("Error al calcular el IVA", SentryLevel.Error);
                throw ex;
            }
            
        }

        [HttpGet("CalculosClientes")]
        public List<Calculo_Cliente> GetCals()
        {
            try
            {
                SentrySdk.CaptureMessage("Get Completo calculos de Clientes", SentryLevel.Info);
                return _service.GetCalculosClientes(_dbConnection);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                SentrySdk.CaptureMessage("Error al obtener los calculos de Clientes", SentryLevel.Error);
                throw ex;
            }
            
        }
    }
}
