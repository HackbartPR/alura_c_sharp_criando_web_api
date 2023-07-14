using Alura___Criando_uma_Web_API.Data;
using Alura___Criando_uma_Web_API.Data.DTOs;
using Alura___Criando_uma_Web_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Alura___Criando_uma_Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly FilmeContext _context;
    private readonly IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDTO)
    {
        Filme filme = _mapper.Map<Filme>(filmeDTO);
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
