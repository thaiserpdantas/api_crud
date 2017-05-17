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

        public async void AtualizarCliente(Cliente item)
        {

            if (item != null)
            {
                var filter = Builders<Cliente>.Filter.Eq(c => c.nome, item.nome);
                var update = Builders<Cliente>.Update.Set(c => c.telefone, item.telefone);
                var result = await clientesDB.UpdateOneAsync(filter, update);
            }


        }

        public Cliente BuscarCliente(string id)
        {
            throw new NotImplementedException();
        }
    }
}
