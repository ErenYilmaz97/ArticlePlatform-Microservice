using Microservice.Identity.Domain.Exception;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Extension
{
    public static class HttpResponseExtensions
    {
        public static Task ReturnValidationErrorResponse(this HttpResponse response, ValidationException exception)
        {
            response.StatusCode = 400;
            response.ContentType = "application/json";

            return response.WriteAsync(exception.ToString());
        }



        public static Task ReturnBusinessErrorResponse(this HttpResponse response, BusinessException exception)
        {
            response.StatusCode = 400;
            response.ContentType = "application/json";

            return response.WriteAsync(exception.Message);
        }



        public static Task InternalServerErrorResponse(this HttpResponse httpResponse)
        {
            httpResponse.StatusCode = 400;
            httpResponse.ContentType = "application/json";

            return httpResponse.WriteAsync("Sunucu Kaynaklı Bir Hata Oluştu.");
        }
    }
}
