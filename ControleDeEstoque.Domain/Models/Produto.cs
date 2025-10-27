using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoque.API.Domain.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        [ForeignKey("Descricao")]
        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }
    }
}
