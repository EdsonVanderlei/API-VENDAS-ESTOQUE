using ApiCarros.Helpers;
using ApiCarros.Model;
using System.Collections.Generic;

namespace ApiCarros.Repository
{
    public interface IRepositoryEstoque
    {

        List<Carro> ObterTodos(CarroQuery query);
        Carro ObterCarro(int id);
        void Deletar(int id);
        void Atualizar(int id,UpdateQuery carro); 
        void Cadastrar(Carro carro);
        Filter ObterFiltros();

    }
}
