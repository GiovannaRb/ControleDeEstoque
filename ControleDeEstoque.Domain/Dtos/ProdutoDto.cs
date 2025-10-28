namespace ControleDeEstoque.Domain.Dtos
{
    public class ProdutoDto
    {
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public int? Quantidade { get; set; }

        public decimal? Preco { get; set; }

        public string? Categoria { get; set; }
    }
}
