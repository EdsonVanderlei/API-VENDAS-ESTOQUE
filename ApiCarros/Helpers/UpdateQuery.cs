namespace ApiCarros.Helpers
{


#nullable enable
    public class UpdateQuery
    {


        public string? Modelo { get; set; }
        public string? Marca  { get; set; }
        public int? Ano     {get; set; }
        public double? Valor { get; set; }
        public int? Quantidade { get; set; }

    }
}
