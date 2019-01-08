using Projeto_Livraria.Dominio.Entities.Base;
using System;

namespace Projeto_Livraria.Dominio.Entities.Livros
{
    public class Livro : EntityBase
    {
        public long ISBN { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataPublicacao { get; set; }
        public byte[] ImagemCapa { get; set; }
    }
}
