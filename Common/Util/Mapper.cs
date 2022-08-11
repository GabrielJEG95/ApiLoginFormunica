using Newtonsoft.Json;

namespace Common.Util
{
    /// <summary>
    /// Mapea un objeto de tipo T1 a T2
    /// </summary>
    /// <typeparam name="T1">Objeto Inicio</typeparam>
    /// <typeparam name="T2">Objeto Destino</typeparam>
    public partial class Mapper<T1, T2>
    {
        public static T2 Map(T1 entidad)
        {

            //Seralizo el objeto que va ser mapeado
            var serializacion = JsonConvert.SerializeObject(entidad);

            //Deserializo el objeto apuntando al modelo que deberia ser mapeado
            var deserializacion = JsonConvert.DeserializeObject<T2>(serializacion);

            //Creo el objeto a partir de la deseriazalicion
            T2 convertido = deserializacion;

            return convertido;
        }
    }
}