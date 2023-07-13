using Alura___Criando_uma_Web_API.Data;
using Alura___Criando_uma_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alura___Criando_uma_Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly FilmeContext _context;

    public FilmeController(FilmeContext context) 
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] Filme filme)
    {
        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return CreatedAtAction(nameof(BuscarFilme), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> ListarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarFilme(int id)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
            return NotFound();
        
        return Ok(filme);        
    }
}
