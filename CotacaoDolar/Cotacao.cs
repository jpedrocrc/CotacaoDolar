using Newtonsoft.Json;

namespace CotacaoDolar
{
    public class Cotacao
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set;}
        [JsonProperty(PropertyName = "buy")]
        public decimal Buy { get; set; }
        [JsonProperty(PropertyName = "sell")]
        public decimal Sell { get; set; }
        [JsonProperty(PropertyName = "variaton")]
        public decimal Var { get; set; }
    }
}
