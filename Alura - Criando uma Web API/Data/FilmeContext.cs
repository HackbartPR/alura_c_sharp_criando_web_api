using Alura___Criando_uma_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Alura___Criando_uma_Web_API.Data;

public class FilmeContext: DbContext
{
    public DbSet<Filme> Filmes { get; set; }

    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
    { }
}
