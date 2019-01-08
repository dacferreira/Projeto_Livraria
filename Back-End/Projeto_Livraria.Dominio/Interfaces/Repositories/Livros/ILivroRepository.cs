using Projeto_Livraria.Dominio.Entities;
using Projeto_Livraria.Dominio.Entities.Livros;
using Projeto_Livraria.Dominio.Interfaces.Repositories.Base;

namespace Projeto_Livraria.Dominio.Interfaces.Repositories.Livros
{
    public interface ILivroRepository : IRepositoryBase<Livro>
    {
    }
}
