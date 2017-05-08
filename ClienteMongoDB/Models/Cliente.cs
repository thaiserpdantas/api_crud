using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ClienteMongoDB.Models
{
    public class Cliente
    {
        public ObjectId _id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
    }

}
