using System.Collections.Generic;

namespace ApiCarros.Helpers
{
    public class Filter
    {
        public List<string> Marca { get; set; }
        public List<string> Modelo { get; set; }
        public List<int> Ano { get; set; }

        public Filter()
        {
            Ano = new List<int>();
            Modelo = new List<string>();
            Marca = new List<string>();

        }
    }
}
