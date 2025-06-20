using PromocjeAplikacjaProjekt.Extensions;
using BibliotekaAplikacjaProjekt.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using PromocjeAplikacjaProjekt.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .ConfigureApplicationPartManager(apm =>
    {
        apm.ApplicationParts.Clear();
        apm.ApplicationParts.Add(new AssemblyPart(typeof(CouponController).Assembly));
        apm.ApplicationParts.Add(new AssemblyPart(typeof(PointController).Assembly));
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCouponServices();
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
