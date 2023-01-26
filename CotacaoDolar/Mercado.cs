using Newtonsoft.Json;

namespace CotacaoDolar
{
    public class Mercado
    {
        public Mercado()
        {
            this.Cotacao = new Cotacao();
        }
        [JsonProperty(PropertyName = "currencies")]
        public Cotacao Cotacao { get; set; }
    }
}
 