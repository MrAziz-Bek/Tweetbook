using System.Runtime.InteropServices;
using System.ComponentModel;
using Tweetbook.Installers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallAllServicesInAssembly(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();