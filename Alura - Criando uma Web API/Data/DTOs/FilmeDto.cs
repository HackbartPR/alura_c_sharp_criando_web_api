using System.ComponentModel.DataAnnotations;

namespace Alura___Criando_uma_Web_API.Data.DTOs
{
    public class FilmeDto
    {
        [Required(ErrorMessage = "O campo Título não pode ser nulo")]
        [StringLength(100, ErrorMessage = "Tamanho máximo do campo Título é de 50 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Gênero não pode ser nulo")]
        [StringLength(50, ErrorMessage = "Tamanho máximo do campo Gênero é de 50 caracteres")]
        public string Genero { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Duração não pode ser nulo")]
        [Range(70, 600, ErrorMessage = "Duração deve ser maior que 70 min e menor que 600 minutos")]
        public int Duracao { get; set; }
    }
}
