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

// Adicionar configurações do appsettings.json
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

// Configurar conexão com o banco de dados Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

// Configurar serviços e IoC
builder.Services.AddProjectDependencies(connectionString);

// Adicionar controladores e Swagger para documentação
builder.Services.AddControllers();

// Configuração do Swagger com documentação XML
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API de Equipamentos IASI",
        Version = "v1",
        Description = "Documentação da API de Equipamentos para o sistema IASI."
    });

    // Configuração para incluir o arquivo XML de documentação
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
