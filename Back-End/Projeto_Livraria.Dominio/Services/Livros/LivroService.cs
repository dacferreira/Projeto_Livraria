using Projeto_Livraria.Dominio.Entities;
using Projeto_Livraria.Dominio.Entities.Livros;
using Projeto_Livraria.Dominio.Interfaces.Repositories.Livros;
using Projeto_Livraria.Dominio.Interfaces.Services.Livros;
using Projeto_Livraria.Dominio.Services.Base;

namespace Projeto_Livraria.Dominio.Services.Livros
{
    public class LivroService : ServiceBase<Livro>, ILivroService
    {
        public LivroService(ILivroRepository repository) : base(repository)
        {
        }
    }
}
