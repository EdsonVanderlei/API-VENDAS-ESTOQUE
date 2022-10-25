using ApiCarros.Helpers;
using ApiCarros.Model;
using System.Collections.Generic;

namespace ApiCarros.Repository
{
    public interface  IRepositoryCliente
    {


        List<Cliente> ObterClientes();
        Cliente ObterCliente(int id);
        void Deletar(int id);
        void Atualizar(int id, Cliente cliente);

        void Cadastrar(Cliente cliente);



    }
}
