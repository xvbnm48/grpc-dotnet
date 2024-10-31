using GrpcService112.Configuration;
using GrpcService112.Configuration.Mysql;
using GrpcService112.Services;
using GrpcService112.UseCase;
using GrpcService112.UseCase.@interface;
using Microsoft.OpenApi.Models;

namespace GrpcService112
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
            builder.Services.AddScoped<ITicketUseCase, TicketUseCase>();


            builder.Services.AddGrpc();
            builder.Services.AddLogging();
            builder.Services.AddGrpc().AddJsonTranscoding();
            builder.Services.AddHealthChecks();
            builder.Services.AddGrpcSwagger();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GrpcService112", Version = "v1" });
            });


            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GrpcService112 v1"));
            app.Run();
        }
    }
}