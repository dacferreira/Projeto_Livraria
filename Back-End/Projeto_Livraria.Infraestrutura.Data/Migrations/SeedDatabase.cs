using Projeto_Livraria.Dominio.Entities.Livros;
using Projeto_Livraria.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Projeto_Livraria.Infraestrutura.Data.Migrations
{
    public class SeedDatabase
    {
        public void Seed(ModelContext context)
        {
            try
            {
                var listaTelas = GetLivros().ToArray();
                context.Set<Livro>().AddOrUpdate(listaTelas);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private IEnumerable<Livro> GetLivros()
        {
            Livro livro = new Livro();
            livro.Id = Guid.Parse("3A130DFF-E8C3-4F9D-B1C3-F0B902CAB79A");
            livro.Nome = "Novo Livro";
            livro.ISBN = 123456789;
            livro.Preco = 13.8M;
            livro.Autor = "Novo Autor";
            livro.DataPublicacao = DateTime.Now;
            yield return livro;
        }
    }
}
