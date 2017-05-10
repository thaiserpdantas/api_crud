using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ClienteMongoDB.Models
{
    public interface IClienteRepositorio
    {
        IEnumerable<Cliente> GetTodosClientes();
        void AdicionarCliente(Cliente item);
        void RemoverCliente(Cliente item);
        void AtualizarCliente(Cliente item);
        Cliente BuscarCliente(string id);


    }
}
