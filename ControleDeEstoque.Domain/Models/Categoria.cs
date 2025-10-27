using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.API.Domain.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }
    }
}
