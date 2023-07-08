using Alura___Criando_uma_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alura___Criando_uma_Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);

        return CreatedAtAction(nameof(BuscarFilme), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> ListarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarFilme(int id)
    {
        Filme? filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
            return NotFound();
        
        return Ok(filme);        
    }
}
