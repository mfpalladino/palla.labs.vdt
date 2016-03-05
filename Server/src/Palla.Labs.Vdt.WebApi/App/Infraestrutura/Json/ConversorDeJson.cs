using Newtonsoft.Json;

namespace Palla.Labs.Vdt.App.Infraestrutura.Json
{
    public class ConversorDeJson
    {
        public T Deserializar<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}