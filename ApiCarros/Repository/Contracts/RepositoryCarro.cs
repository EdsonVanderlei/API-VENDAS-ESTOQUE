using ApiCarros.Controllers;
using ApiCarros.Data;
using ApiCarros.Helpers;
using ApiCarros.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApiCarros.Repository.Contracts
{
    public class RepositoryCarro : IRepositoryCarros
    {
        private readonly EstoqueContext _bancoEstoque;
        private readonly VendasContext _banco;
        public RepositoryCarro(VendasContext banco, EstoqueContext banco2)
        {
            _bancoEstoque = banco2;
            _banco = banco;
        }

        public bool CadastrarCarro(CarroVendido carro)
        {

           var obj =  _bancoEstoque.Carros.FirstOrDefault(p => p.Modelo == carro.Modelo && p.Ano == carro.Ano && p.Quantidade > 0);
           if(obj == null)
            {
                return false; 
            }

            var placa = _banco.CarrosVendidos.Where(p => p.Placa == carro.Placa);


            if (placa.Any())
            {
                return false;
            }
            obj.Quantidade -= 1;
            _bancoEstoque.SaveChanges();



            _banco.CarrosVendidos.Add(carro);   

            

            _banco.SaveChanges();

            return true;
        }

        public List<CarroVendido> ObterCarros()
        {
            var obj = _banco.CarrosVendidos.ToList();
            return obj;
        }
    }
}
