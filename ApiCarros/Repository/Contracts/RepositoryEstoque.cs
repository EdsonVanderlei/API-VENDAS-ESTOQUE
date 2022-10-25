using ApiCarros.Data;
using ApiCarros.Helpers;
using ApiCarros.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApiCarros.Repository.Contracts
{
    public class RepositoryEstoque : IRepositoryEstoque
    {

        private readonly EstoqueContext _banco;

        public RepositoryEstoque( EstoqueContext banco) 
        {
            _banco = banco;
        }



        public void Atualizar(int id, UpdateQuery carro)
        {
            var obj = _banco.Carros.FirstOrDefault(x => x.Id == id);

            if (carro.Modelo != null) obj.Modelo = carro.Modelo;

            if (carro.Ano.HasValue) obj.Ano = (int)carro.Ano;

            if(carro.Marca != null) obj.Marca = carro.Marca;

            if (carro.Quantidade.HasValue) obj.Quantidade = (int)carro.Quantidade;

            if (carro.Valor.HasValue) obj.Valor = (double)carro.Valor;

            


            _banco.Carros.Update(obj);
            _banco.SaveChanges();




        }

        public void Cadastrar(Carro carro)
        {

            _banco.Carros.Add(carro);
            _banco.SaveChanges();
           
        }

        public void Deletar(int id)
        {


            var obj = ObterCarro(id);

            _banco.Carros.Remove(obj);
            _banco.SaveChanges();




        }

        public Carro ObterCarro(int id)
        {
            var obj = _banco.Carros.AsNoTracking().FirstOrDefault(p => p.Id == id);
            return obj;


        }

        public Filter ObterFiltros()
        {

            Filter filter = new Filter();
            var obj = _banco.Carros.AsNoTracking().AsQueryable();
          
           
            

            
            foreach(var item in obj)
            {
                filter.Marca.Add(item.Marca);
                filter.Modelo.Add(item.Modelo);
                filter.Ano.Add(item.Ano);
            }



            filter.Marca = filter.Marca.Distinct().ToList();
            filter.Modelo = filter.Modelo.Distinct().ToList();




            return filter; 



        }

        public List<Carro> ObterTodos(CarroQuery query)
        {
            var obj = _banco.Carros.AsNoTracking().AsQueryable();
            if (query.Ano.HasValue)
            {
               obj = obj.Where(p => p.Ano == query.Ano);
            }
            if (query.Marca != null)
            {
                obj = obj.Where(p => p.Marca == query.Marca);
            }
            if(query.Modelo != null)
            {
                obj = obj.Where(p => p.Modelo == query.Modelo);
            }
            if (query.MaxValor.HasValue)
            {
                obj = obj.Where(p => p.Valor <= query.MaxValor);
            }

            if(query.Pagina.HasValue && query.NumCarros.HasValue)
            {
                obj = obj.Skip((query.Pagina.Value -1) * query.NumCarros.Value).Take(query.NumCarros.Value);
            }


            return obj.ToList();
        }

       
    }
}
