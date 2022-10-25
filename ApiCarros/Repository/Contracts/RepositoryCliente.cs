using ApiCarros.Data;
using ApiCarros.Helpers;
using ApiCarros.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApiCarros.Repository.Contracts
{
    public class RepositoryCliente : IRepositoryCliente
    {

        private readonly VendasContext _bancoVendas;

        public RepositoryCliente(VendasContext context)
        {
            _bancoVendas = context;
        }

        public void Atualizar(int id, Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public void Cadastrar(Cliente cliente)
        {
            _bancoVendas.Clientes.Add(cliente);
            _bancoVendas.SaveChanges();
            

        }

        public void Deletar(int id)
        {
            throw new System.NotImplementedException();
        }

        public Cliente ObterCliente(int id)
        {
            var obj = _bancoVendas.Clientes.Include(p => p.Carros).FirstOrDefault(p => p.Id == id);
            return obj;
        }

        public List<Cliente> ObterClientes()
        {
            return _bancoVendas.Clientes.Include(p => p.Carros).ToList();
        }

       
    }
}
