using System;
using System.Collections.Generic;

namespace Common.Referencias
{
    public class Estado
    {
        public static int Registrado = 1;
        public static int SolicitudActivación = 2;
        public static int Activo = 3;
        public static int SolicitudBaja = 4;
        public static int DeBaja = 5;
    }

    public class TipoCliente
    {
        public static int Natural = 1;
        public static int Jurídico = 2;
    }
}
