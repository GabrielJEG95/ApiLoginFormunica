using System.Reflection;
using System.Collections.Generic;
using System;

namespace Common.Util
{
    public class PropiedadValor
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }

    }

    public static class metodo
    {
        public static List<PropiedadValor> ConvertirObjetoAListPropiedadValor(Object objeto)
        {
            List<PropiedadValor> lPropiedadValor = new List<PropiedadValor>();

            foreach (PropertyInfo propiedad in objeto.GetType().GetProperties())
            {
                var asc = propiedad.GetValue(objeto);
                if (propiedad.GetValue(objeto) != null
                    && (!propiedad.Name.Contains("registroPorPagina"))
                    && (!propiedad.Name.Contains("pagina"))
                    && (!propiedad.Name.Contains("OrdenarPor"))
                )
                {
                    PropiedadValor oPropiedadValor = new PropiedadValor();
                    oPropiedadValor.Nombre = propiedad.Name;
                    oPropiedadValor.Valor = propiedad.GetValue(objeto).ToString();

                    lPropiedadValor.Add(oPropiedadValor);
                }

            }

            return lPropiedadValor;
        }
        public static string ConvertirObjetoAstringURL(Object objeto)
        {
            List<PropiedadValor> lPropiedadValor = new List<PropiedadValor>();

            string query = "";
            int contador = 0;

            foreach (PropertyInfo propiedad in objeto.GetType().GetProperties())
            {
                var asc = propiedad.GetValue(objeto);
                if (propiedad.GetValue(objeto) != null)
                {
                    PropiedadValor oPropiedadValor = new PropiedadValor();
                    oPropiedadValor.Nombre = propiedad.Name;
                    oPropiedadValor.Valor = propiedad.GetValue(objeto).ToString();

                    if (contador == 0)
                        query += "?" + propiedad.Name + "=" + oPropiedadValor.Valor;
                    else
                        query += "&" + propiedad.Name + "=" + oPropiedadValor.Valor;

                    ++contador;
                }

            }

            return query;
        }
    }





}