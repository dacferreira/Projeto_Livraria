using System;

namespace Projeto_Livraria.Web.Api.Dto
{
    public class LivroDto
    {
        public Guid Id { get; set; }
        public long ISBN { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataPublicacao { get; set; }
        public byte[] ImagemCapa { get; set; }
        public string ImagemCapa2 { get; set; }
    }
}