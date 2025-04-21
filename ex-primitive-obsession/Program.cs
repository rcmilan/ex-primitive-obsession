using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;

namespace ex_primitive_obsession
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options
                    .WithTitle("No Primitive Obsession")
                    .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
