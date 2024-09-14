using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using IASI.Equipamentos.Infrastructure.IoC;
using Microsoft.EntityFrameworkCore;
using IASI.Equipamentos.Infrastructure.Data; // Certifique-se de importar o namespace correto para seu AppDbContext
using System.Reflection;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Adicionar configura��es do appsettings.json
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

// Configurar conex�o com o banco de dados Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

// Configurar servi�os e IoC
builder.Services.AddProjectDependencies(connectionString);

// Adicionar controladores e Swagger para documenta��o
builder.Services.AddControllers();

// Configura��o do Swagger com documenta��o XML
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API de Equipamentos IASI",
        Version = "v1",
        Description = "Documenta��o da API de Equipamentos para o sistema IASI."
    });

    // Configura��o para incluir o arquivo XML de documenta��o
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configurar o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Equipamentos IASI v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
