using FluentAssertions;
using Projeto_Livraria.Aplicacao.Services.Livros;
using Projeto_Livraria.Dominio.Entities.Livros;
using Projeto_Livraria.Dominio.Excecoes;
using Projeto_Livraria.TestesUnitarios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Projeto_Livraria.TestesUnitarios.Livros
{
    public class LivroAppServiceAdicionarTest : AppServiceBaseTest
    {
        private readonly LivroAppService _appService;

        public LivroAppServiceAdicionarTest()
        {
            _appService = _mocker.Resolve<LivroAppService>();
        }

        private Livro GerarLivro()
        {
            var livro = new Livro
            {
                Id = Guid.NewGuid(),
                ISBN = 99,
                Autor = "Diogo",
                Nome = "Livro do Diogo",
                Preco = 20,
                DataPublicacao = DateTime.Now,
            };
            return livro;
        }

        [Fact]
        public void AdicionarSucesso()
        {
            var livro = GerarLivro();
            _appService
                .Invoking(x => x.ADD(livro))
                .Should()
                .NotThrow<ValidacaoException>();
        }
        [Fact]
        public void AdicionarComPrecoVazio()
        {
            var livro = GerarLivro();
            livro.Preco = 0;
            _appService
                .Invoking(x => x.ADD(livro))
                .Should()
                .Throw<ValidacaoException>()
                .WithMessage("Campos Inválidos")
                .And
                .ObterErros()
                .Should()
                .Contain(erro => erro.Mensagem == "O Campo Preço deve ser informado.");
        }
        [Fact]
        public void AdicionarComISBNVazio()
        {
            var livro = GerarLivro();
            livro.ISBN = 0;
            _appService
                .Invoking(x => x.ADD(livro))
                .Should()
                .Throw<ValidacaoException>()
                .WithMessage("Campos Inválidos")
                .And
                .ObterErros()
                .Should()
                .Contain(erro => erro.Mensagem == "O Campo ISBN deve ser informado.");
        }
        [Fact]
        public void AdicionarComAutorVazio()
        {
            var livro = GerarLivro();
            livro.Autor = string.Empty;
            _appService
                .Invoking(x => x.ADD(livro))
                .Should()
                .Throw<ValidacaoException>()
                .WithMessage("Campos Inválidos")
                .And
                .ObterErros()
                .Should()
                .Contain(erro => erro.Mensagem == "O Campo Autor deve ser informado.");
        }
        [Fact]
        public void AdicionarComNomeVazio()
        {
            var livro = GerarLivro();
            livro.Nome = string.Empty;
            _appService
                .Invoking(x => x.ADD(livro))
                .Should()
                .Throw<ValidacaoException>()
                .WithMessage("Campos Inválidos")
                .And
                .ObterErros()
                .Should()
                .Contain(erro => erro.Mensagem == "O Campo Nome deve ser informado.");
        }

        [Fact]
        public void AdicionarComDataPublicacaoVazio()
        {
            var livro = GerarLivro();
            livro.DataPublicacao = DateTime.MinValue;
            _appService
                .Invoking(x => x.ADD(livro))
                .Should()
                .Throw<ValidacaoException>()
                .WithMessage("Campos Inválidos")
                .And
                .ObterErros()
                .Should()
                .Contain(erro => erro.Mensagem == "O Campo Data Publicação deve ser informado.");
        }
    }
}
