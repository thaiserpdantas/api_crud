using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClienteMongoDB.Models;
using MongoDB.Bson;
using NLog;

namespace API_CRUD.Controller
{
    [RoutePrefix(@"cliente")]
    public class ClienteController : ApiController
    {
        private ILogger _logger = null;
        public IClienteRepositorio clienteRepo { get; set; }

        public ClienteController()
        {
            this._logger = LogManager.GetLogger("API_CRUD_Log");
            clienteRepo = new ClienteRepositorio();
        }



        [HttpPost]
        [Route("adicionar")]
        public IHttpActionResult Adicionar(Cliente item)
        {
            IHttpActionResult result = null;
            try
            {
                clienteRepo.AdicionarCliente(item);
                _logger.Info(string.Format("Request Data: {0}", item));
                result = Ok<Cliente>(item);
            }
            catch (Exception ex)
            {
                this._logger.Fatal("Error: ", ex, null);
                result = InternalServerError();
            }
            return result;
        }


        [HttpGet]
        [Route("consulta")]
        public IEnumerable<Cliente> GetCliente()
        {
            _logger.Info("Log do GET");
            return clienteRepo.GetTodosClientes();
        }

        [HttpPut]
        [Route("atualizar")]
        public void Atualizar(Cliente item)
        {
            _logger.Info("Log do PUT");
            clienteRepo.AtualizarCliente(item);
        }


        [HttpDelete]
        [Route("apagar")]
        public void Remover(Cliente item)
        {
            _logger.Info("Log do DELETE");
            clienteRepo.RemoverCliente(item);
        }

    }
}
