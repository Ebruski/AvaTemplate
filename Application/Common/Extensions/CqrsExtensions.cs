using Application.Common.Exceptions;
using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Net;
using System.Reflection;
using System.Text.Json;

namespace Application.Common.Extensions
{
    public static class CQRSExtensions
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var statusCode = context.Response.StatusCode;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log.Error(contextFeature.Error, "An Error Occured");
                        var response = ResponseModel.Failure("303");
                        
                        if (contextFeature.Error is CustomException ce)
                            response = ResponseModel.Failure(ce.Code);
                        else if (contextFeature.Error is FluentValidation.ValidationException ve)
                            response = ResponseModel.Vf(string.Join(", ", ve.Errors));

                        //response.Data.En = contextFeature.Error.ToString();
                        var options = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        };
                        await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
                    }
                });
            });
        }

    }
}
