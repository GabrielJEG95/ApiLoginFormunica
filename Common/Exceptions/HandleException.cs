using System;
using Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Common.Exceptions
{
    public static class HandleException
    {
        public static ObjectResult GetExceptionResult(Exception ex)
        {
            ObjectResult objRes = new ObjectResult(ex.Message);
            objRes.StatusCode = StatusCodes.Status500InternalServerError;

            if (ex is HttpStatusException httpStatusEx)
            {
                objRes.StatusCode = (int)httpStatusEx.StatusCode;
                objRes.Value = httpStatusEx.Message;
            }

            return objRes;
        }
    }
}