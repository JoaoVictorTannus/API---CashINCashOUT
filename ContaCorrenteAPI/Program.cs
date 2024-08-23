using ContaCorrenteAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Adicionando a api ao banco de dados
builder.Services.AddControllers();
builder.Services.AddDbContext<ContaCorrenteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
// Configuração do swagger/http para acesso web.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContaCorrenteAPI v1");
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
