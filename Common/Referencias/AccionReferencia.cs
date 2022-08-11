namespace Common.Referencias
{
    public enum Accion
    {
        Acceder, Nuevo, Editar, Eliminar
    }
    public class AccionReferencia
    {
        public string Acceder { get; set; }
        public string Nuevo { get; set; }
        public string Editar { get; set; }
        public string Eliminar { get; set; }

    }

}