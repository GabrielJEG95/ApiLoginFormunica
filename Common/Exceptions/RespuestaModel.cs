using System;
using System.IO;
using Common.Referencias;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Common.Exceptions
{
    public class RespuestaModel
    {

        public int statusCode { get; set; }
        public string mensaje { get; set; }

        public static RespuestaModel ProcesarExcepción(Exception ex)
        {
            var error = new RespuestaModel();
            error.mensaje = ex.Message;
            if (ex is FileNotFoundException)
            {   //El servidor no pudo encontrar el contenido solicitado.
                error.statusCode = StatusCodes.Status404NotFound;
            }
            else if (ex is InvalidOperationException)
            {
                error.statusCode = StatusCodes.Status404NotFound;
            }
            else if (ex is NullReferenceException)
            {
                error.statusCode = StatusCodes.Status404NotFound;
            }
            else if (ex is ArgumentNullException)
            {
                error.statusCode = StatusCodes.Status400BadRequest;
            }

            else if (ex is ArgumentException || ex is FormatException)
            {
                //el servidor no pudo interpretar la solicitud dada una sintaxis inválida
                error.statusCode = StatusCodes.Status400BadRequest;
            }
            else if (ex is DbUpdateException)
            {
                error.statusCode = StatusCodes.Status500InternalServerError;
                error.mensaje = "Ocurrio un error al procesar la peticion - BD";
                // error.mensaje = ex.Message;
            }
            else
            {
                error.statusCode = StatusCodes.Status500InternalServerError;
                error.mensaje = ex.Message;
                //error.mensaje = ex.Message;
            }
            //error.exceptionName = ex.GetType().Name;
            // return StatusCode(error.statusCode, new { error = error });
            return error;

        }

        /// <summary>
        /// Envia mensaje por defecto 
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static RespuestaModel CreacionExitosa(string mensaje = null)
        {
            mensaje ??= MensajeReferencia.CreacionExitosa;

            return new RespuestaModel()
            {
                statusCode = StatusCodes.Status200OK,
                mensaje = mensaje
            };
        }
        public static RespuestaModel ActualizacionExitosa(string mensaje = null)
        {
            mensaje ??= MensajeReferencia.ActualizacionExitosa;

            return new RespuestaModel()
            {
                statusCode = StatusCodes.Status200OK,
                mensaje = mensaje
            };
        }
        public static RespuestaModel EliminacionExitosa(string mensaje = null)
        {
            mensaje ??= MensajeReferencia.EliminacionExitosa;

            return new RespuestaModel()
            {
                statusCode = StatusCodes.Status200OK,
                mensaje = mensaje
            };
        }
        public static RespuestaModel NoEncontrado(string mensaje = null)
        {
            mensaje ??= MensajeReferencia.RegistroNoEncontrado;

            return new RespuestaModel()
            {
                statusCode = StatusCodes.Status200OK,
                mensaje = mensaje
            };
        }


    }


}
