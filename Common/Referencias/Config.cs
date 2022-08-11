using Microsoft.Extensions.Options;

namespace Common.Referencias
{
    public interface IConfig
    {
        string HomologacionPantalla(Pantalla pantalla);
        string HomologacionAccion(Accion accion);
    }

    public class Config : IConfig
    {
        private readonly PantallaReferencia _pantallaReferencia;
        private readonly AccionReferencia _accionReferencia;
        // public Config(IOptions<PantallaReferencia> configPantalla, IOptions<AccionReferencia> accionReferencia)
        // {
        //     _pantallaReferencia = configPantalla.Value;
        //     _accionReferencia = accionReferencia.Value;
        // }
        public Config(IOptionsSnapshot<PantallaReferencia> configPantalla, IOptionsSnapshot<AccionReferencia> accionReferencia)
        {
            _pantallaReferencia = configPantalla.Value;
            _accionReferencia = accionReferencia.Value;
        }

        public string HomologacionAccion(Accion accion)
        {
            string accion2 = "";
            switch (accion)
            {
                case Accion.Acceder:
                    accion2 = _accionReferencia.Acceder;
                    break;

                case Accion.Editar:
                    accion2 = _accionReferencia.Editar;
                    break;
                case Accion.Eliminar:
                    accion2 = _accionReferencia.Eliminar;
                    break;
                case Accion.Nuevo:
                    accion2 = _accionReferencia.Nuevo;
                    break;
                default:
                    accion2 = "---";
                    break;
            }
            return accion2;

        }

        public string HomologacionPantalla(Pantalla pantalla)
        {

            string pantalla2 = "";
            switch (pantalla)
            {
                case Pantalla.Anualidad:
                    pantalla2 = _pantallaReferencia.Anualidad;
                    break;
                case Pantalla.TipoCobro:
                    pantalla2 = _pantallaReferencia.TipoCobro;
                    break;
                case Pantalla.Antiguedad:
                    pantalla2 = _pantallaReferencia.Antiguedad;
                    break;
                case Pantalla.ArancelArea:
                    pantalla2 = _pantallaReferencia.ArancelArea;
                    break;
                case Pantalla.NivelCliente:
                    pantalla2 = _pantallaReferencia.NivelCliente;
                    break;
                case Pantalla.TipoCancelacion:
                    pantalla2 = _pantallaReferencia.TipoCancelacion;
                    break;
                case Pantalla.TipoDescuento:
                    pantalla2 = _pantallaReferencia.TipoDescuento;
                    break;
                case Pantalla.Cliente:
                    pantalla2 = _pantallaReferencia.Cliente;
                    break;
                case Pantalla.ClienteArancel:
                    pantalla2 = _pantallaReferencia.ClienteArancel;
                    break;
                case Pantalla.ResponsableCartera:
                    pantalla2 = _pantallaReferencia.ResponsableCartera;
                    break;
                case Pantalla.Paquete:
                    pantalla2 = _pantallaReferencia.Paquete;
                    break;
                default:
                    pantalla2 = "---";
                    break;
            }
            return pantalla2;
        }
    }
}