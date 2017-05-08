using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClienteMongoDB.Models;
using MongoDB.Bson;

namespace API_CRUD.Controller
{
    [RoutePrefix(@"cliente")]
    public class ClienteController : ApiController
    {
        public IClienteRepositorio clienteRepo { get; set; }

        public ClienteController()
        {
            clienteRepo = new ClienteRepositorio();
        }


        [HttpPost]
        [Route("adicionar")]
        public void Adicionar(Cliente item)
        {
            clienteRepo.AdicionarCliente(item);
        }
        

        [HttpGet]
        [Route("consulta/{id}", Name = "GetClientes")]
        public IEnumerable<Cliente> GetCliente()
        {
            return clienteRepo.GetTodosClientes();
            
        }

        [HttpPut]
        public void Atualizar(Cliente item)
        {
            clienteRepo.AtualizarCliente(item);

        }




        [HttpDelete]
        [Route("apagar")]
        public void Remover(string _id)
        {
            clienteRepo.RemoverCliente(ObjectId.Parse(_id));
        }

    }
}
