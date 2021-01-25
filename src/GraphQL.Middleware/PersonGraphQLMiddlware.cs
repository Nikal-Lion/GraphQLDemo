using GraphQL.Interfaces;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace GraphQL.Middleware
{
    public class PersonGraphQLMiddlware
    {
        private readonly RequestDelegate _next;
        private readonly IPersonRepository _personRepository;

        public PersonGraphQLMiddlware(RequestDelegate next, IPersonRepository personRepository)
        {
            this._next = next;
            this._personRepository = personRepository;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/graphql", StringComparison.InvariantCultureIgnoreCase))
            {
                using var stream = new StreamReader(httpContext.Request.Body);
                string query = await stream.ReadToEndAsync();
                if (!string.IsNullOrWhiteSpace(query))
                {
                    Schema schema = new Schema { Query = new PersonQuery(_personRepository) };
                    var result = await new DocumentExecuter()
                        .ExecuteAsync(options =>
                        {
                            options.Schema = schema;
                            options.Query = query;
                        });
                    await WriteResultAsyc(httpContext, result);
                }
            }
        }

        private async Task WriteResultAsyc(HttpContext httpContext, ExecutionResult result)
        {
            var json = await new DocumentWriter(indent: true).WriteToStringAsync(result);

            httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }
    }
}