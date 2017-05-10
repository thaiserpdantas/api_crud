using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;


namespace ClienteMongoDB.Models
{
    public class ClienteRepositorio : IClienteRepositorio
    {

        string connectionString = "mongodb://localhost:27017";
        IMongoCollection<Cliente> clientesDB;


        public ClienteRepositorio()
        {
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("DataBaseAPI_CRUD");
            clientesDB = db.GetCollection<Cliente>("clientes");
        }


        public IEnumerable<Cliente> GetTodosClientes()
        {
            IEnumerable<Cliente> clientes = clientesDB
               .Find(_ => true).ToList();
            return clientes;
        }

        public void AdicionarCliente(Cliente item)
        {
            clientesDB.InsertOne(item);           

        }

        public void RemoverCliente(Cliente item)
        {
           clientesDB.DeleteOne(c => c.nome == item.nome);

        }

        public void AtualizarCliente(Cliente item)
        {
            Cliente itemAtualizar = clientesDB.Find(c => c.nome == item.nome).ToList().First();
            if (itemAtualizar != null)
            {
                itemAtualizar.nome = item.nome;
                itemAtualizar.telefone = item.telefone;
            }
        }

        public Cliente BuscarCliente(string id)
        {
            throw new NotImplementedException();
        }
    }
}
