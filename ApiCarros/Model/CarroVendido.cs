using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCarros.Model
{
    public class CarroVendido
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public double Valor { get; set; }
        public string Placa { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        
    }
}
