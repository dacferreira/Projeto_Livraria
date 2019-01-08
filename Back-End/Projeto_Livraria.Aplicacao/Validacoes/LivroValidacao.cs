using FluentValidation;
using Projeto_Livraria.Dominio.Entities.Livros;
using Projeto_Livraria.Dominio.Interfaces.Repositories.Livros;
using Projeto_Livraria.Dominio.Interfaces.Services.Livros;
using System;
using System.Linq;

namespace Projeto_Livraria.Aplicacao.Validacoes
{
    public class LivroValidacao : AbstractValidator<Livro>
    {
        protected void ValidarISBN(ILivroService livroRepository)
        {
            RuleFor(x => x.ISBN)
            .NotEmpty()
            .WithMessage(x => "O Campo ISBN deve ser informado.");

            RuleFor(p => p.ISBN)
               .Must((entidade, isbn) => !livroRepository.GetAll().Any(n => n.ISBN == isbn && n.Id != entidade.Id))
               .WithMessage(p => "O ISBN já está sendo utilizado.");
        }

        protected void ValidarAutor()
        {
            RuleFor(x => x.Autor)
            .NotEmpty()
            .WithMessage(x => "O Campo Autor deve ser informado.");
        }

        protected void ValidarNome()
        {
            RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage(x => "O Campo Nome deve ser informado.");
        }

        protected void ValidarPreco()
        {
            RuleFor(x => x.Preco)
            .NotEmpty()
            .WithMessage(x => "O Campo Preço deve ser informado.");

            RuleFor(x => x.Preco)
                .GreaterThanOrEqualTo(0)
                .WithMessage(x => "O Preço do livro deve ser maior que zero.");

        }

        protected void ValidarDataPublicacao()
        {
            RuleFor(x => x.DataPublicacao)
            .NotEqual(DateTime.MinValue)
            .WithMessage(x => "O Campo Data Publicação deve ser informado.");
        }
    }
}
