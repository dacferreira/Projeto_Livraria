using Projeto_Livraria.Aplicacao.Interfaces.Livros;
using Projeto_Livraria.Aplicacao.Services.Base;
using Projeto_Livraria.Aplicacao.Validacoes;
using Projeto_Livraria.Dominio.Entities.Livros;
using Projeto_Livraria.Dominio.Excecoes;
using Projeto_Livraria.Dominio.Interfaces.Services.Livros;

namespace Projeto_Livraria.Aplicacao.Services.Livros
{
    public class LivroAppService : AppServiceBase<Livro>, ILivroAppService
    {
        private readonly ILivroService _livroService;
        public LivroAppService(ILivroService livroService) : base(livroService)
        {
            _livroService = livroService;
        }

        public override void ADD(Livro obj)
        {
            var validador = new AdicionarLivroValidacao(_livroService);
            var resultadoValidacao = validador.Validate(obj);

            if (!resultadoValidacao.IsValid)
            {
                throw new ValidacaoException("Campos Inválidos", resultadoValidacao.Errors);
            }

            base.ADD(obj);
        }

        public override void Update(Livro obj)
        {
            var validador = new AlterarLivroValidacao(_livroService);
            var resultadoValidacao = validador.Validate(obj);

            if (!resultadoValidacao.IsValid)
            {
                throw new ValidacaoException("Campos Inválidos", resultadoValidacao.Errors);
            }

            base.Update(obj);
        }
    }
}
