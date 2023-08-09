﻿using E_BookStore_B.Errors;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace E_BookStore_B.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                ApiError response;
                HttpStatusCode statusCode=HttpStatusCode.InternalServerError;
                String message;
                var exceptionType=ex.GetType();
                if (exceptionType== typeof(UnauthorizedAccessException))
                {
                    statusCode= HttpStatusCode.Forbidden;
                    message= "Niste ovlašćeni!";
                }
                else
                {
                    statusCode= HttpStatusCode.InternalServerError;
                    message = "Dogodila se neka nepoznata greška!";
                }
                if (env.IsDevelopment())
                {
                    response = new ApiError((int)statusCode, ex.Message, ex.StackTrace.ToString());
                }
                else
                {
                    response = new ApiError((int)statusCode, message);
                }
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "aplication/json";
                await context.Response.WriteAsync(response.ToString());
            }
        }
    }
}
