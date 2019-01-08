using Projeto_Livraria.Dominio.Interfaces.Repositories.Livros;
using Projeto_Livraria.Dominio.Interfaces.Services.Livros;

namespace Projeto_Livraria.Aplicacao.Validacoes
{
    public class AdicionarLivroValidacao : LivroValidacao
    {
        public AdicionarLivroValidacao(ILivroService service)
        {
            ValidarISBN(service);
            ValidarAutor();
            ValidarNome();
            ValidarPreco();
            ValidarDataPublicacao();
        }
    }
}
