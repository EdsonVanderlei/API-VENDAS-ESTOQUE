using ApiCarros.Controllers;
using ApiCarros.Helpers;
using ApiCarros.Model;
using System.Collections.Generic;

namespace ApiCarros.Repository
{
    public interface IRepositoryCarros
    {
        List<CarroVendido> ObterCarros();
        bool CadastrarCarro (CarroVendido query);    


    }
}
