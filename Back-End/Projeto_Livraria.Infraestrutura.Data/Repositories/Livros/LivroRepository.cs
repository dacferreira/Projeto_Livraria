using Projeto_Livraria.Dominio.Entities.Livros;
using Projeto_Livraria.Dominio.Interfaces.Repositories.Livros;
using Projeto_Livraria.Infraestrutura.Data.Repositories.Base;

namespace Projeto_Livraria.Infraestrutura.Data.Repositories.Livros
{
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
    }
}
