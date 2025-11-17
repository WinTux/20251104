using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace segundoEjemploASPNET.Herramientas
{
    public static class ConversorSesiones
    {
        public static void ConvertirAJson(this ISession sesion, string key, object value)
        {
            sesion.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T ConvertirDesdeJson<T>(this ISession sesion, string key)
        {
            var value = sesion.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
