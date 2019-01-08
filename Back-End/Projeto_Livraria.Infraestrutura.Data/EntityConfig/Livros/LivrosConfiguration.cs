using Projeto_Livraria.Dominio.Entities.Livros;
using System.Data.Entity.ModelConfiguration;

namespace Projeto_Livraria.Infraestrutura.Data.EntityConfig.Livros
{
    public class LivrosConfiguration : EntityTypeConfiguration<Livro>
    {
        public LivrosConfiguration()
        {
            HasKey(livro => livro.Id);

            Property(livro => livro.Autor)
                .IsRequired()
                .HasMaxLength(150);

            Property(livro => livro.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(livro => livro.Preco)
                .IsRequired()
                .HasPrecision(15, 2);

            Property(livro => livro.DataPublicacao)
                .IsRequired();

            Property(livro => livro.ImagemCapa)
                .IsOptional();

            ToTable("TB_LIVRO");
        }
    }
}
