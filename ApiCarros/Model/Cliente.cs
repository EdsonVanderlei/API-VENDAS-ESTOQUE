using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiCarros.Model
{

    
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public string Cpf { get; set; }


        public virtual List<CarroVendido> Carros { get; set; }
    }
}
