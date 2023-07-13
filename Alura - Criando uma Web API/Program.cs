using Alura___Criando_uma_Web_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do serviço de conexão com o banco de dados, a partir deste momento podemos utilizar a injeção de dependencia do Context em qualquer lugar
string connectionString = builder.Configuration.GetConnectionString("FilmeConnection");
var serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddDbContext<FilmeContext>(dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
