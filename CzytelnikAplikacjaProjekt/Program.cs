using CzytelnikAplikacjaProjekt.Extensions;
using BibliotekaAplikacjaProjekt.Extensions;
using PromocjeAplikacjaProjekt.Extensions;
using CzytelnikAplikacjaProjekt.Resolver;
using CzytelnikAplikacjaProjekt.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
namespace CzytelnikAplikacjaProjekt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .ConfigureApplicationPartManager(apm =>
                {
                    apm.ApplicationParts.Clear();
                    apm.ApplicationParts.Add(new AssemblyPart(typeof(ReaderController).Assembly));
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddReaderService();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient<OrderResolver>();
            builder.Services.AddHttpClient<CouponResolver>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
