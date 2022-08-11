using System;

namespace Common.Referencias
{
    public class PantallaReferencia
    {

        public string Anualidad { get; set; }
        public string Mora { get; set; }
        public string ArancelArea { get; set; }
        public string ParametrizacionPago { get; set; }

        public string DetalleArancel { get; set; }
        public string TipoCobro { get; set; }
        public string Antiguedad { get; set; }
        public string cartera { get; set; }
        public string NivelCliente { get; set; }
        public string TipoCancelacion { get; set; }
        public string TipoDescuento { get; set; }
        public string Cliente { get; set; }
        public string ClienteArancel { get; set; }
        public string ResponsableCartera { get; set; }
        public string Paquete { get; set; }

    }
    public enum Pantalla
    {
        Anualidad,
        Mora,
        ArancelArea,
        ParametrizacionPago,
        DetalleArancel,
        TipoCobro,
        Antiguedad,
        NivelCliente,
        TipoCancelacion,
        Cartera,
        TipoDescuento,
        Cliente,
        ClienteArancel,
        ResponsableCartera,
        Paquete
    }
}