using Alura___Criando_uma_Web_API.Data;
using Alura___Criando_uma_Web_API.Data.DTOs;
using Alura___Criando_uma_Web_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    public IActionResult AdicionarFilme([FromBody] FilmeDto filmeDTO)
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

    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id, FilmeDto filmeDto)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) 
            return NotFound();

        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarFilmeParcialmente(int id, [FromBody] JsonPatchDocument<FilmeDto> patch)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(filme=>filme.Id == id);

        if (filme == null)
            return NotFound();

        FilmeDto filmeDto = _mapper.Map<FilmeDto>(filme);
        patch.ApplyTo(filmeDto, ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();

        return NoContent();
    }
}
