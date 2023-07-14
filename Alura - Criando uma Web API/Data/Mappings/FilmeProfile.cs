using Alura___Criando_uma_Web_API.Data.DTOs;
using Alura___Criando_uma_Web_API.Models;
using AutoMapper;

namespace Alura___Criando_uma_Web_API.Data.Mappings;

public class FilmeProfile : Profile
{
    public FilmeProfile() 
    {
        CreateMap<Filme,CreateFilmeDto>().ReverseMap();
    }
}
