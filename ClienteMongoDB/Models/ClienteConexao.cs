using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ClienteMongoDB.Models
{
    class ClienteConexao
    {
        string connectionString = "mongodb://localhost:27017";
        public ClienteConexao()
        {            
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("DataBaseAPI");
            var clientesDB = db.GetCollection<Cliente>("cidades");
        }

    }
}
