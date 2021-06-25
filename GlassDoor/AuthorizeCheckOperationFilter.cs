using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GlassDoor
{
    // Swagger IOperationFilter implementation that will decide which api action needs authorization
    internal class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>()
                .Distinct();

            var allowsAnonymous = context.MethodInfo.GetCustomAttributes(true)
                .OfType<AllowAnonymousAttribute>().Distinct();
            //var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
            //    .Union(context.MethodInfo.GetCustomAttributes(true))
            //    .OfType<AuthorizeAttribute>()
            //    .Any();

            if (authAttributes.Any() && !allowsAnonymous.Any())
            {

                operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });

                var jwtbearerScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                };

                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        [ jwtbearerScheme ] = new string [] { }
                    }
                };
            }
        }
    }
}
