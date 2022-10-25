namespace ApiCarros.Helpers
{

    #nullable enable
    public class CarroQuery
    {
        public int? Ano  { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public double? MaxValor { get; set; }

        public int? NumCarros { get; set; }
        public int? Pagina { get; set; }

    }
}
