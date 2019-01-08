using Projeto_Livraria.Dominio.Entities.Livros;
using Projeto_Livraria.Infraestrutura.Data.EntityConfig.Livros;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Projeto_Livraria.Infraestrutura.Data.Context
{
    public class ModelContext : DbContext
    {
        public ModelContext()
         : base("LivroContext")
        {

        }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new LivrosConfiguration());
        }
        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegisterDate") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //            entry.Property("RegisterDate").CurrentValue = DateTime.Now;

        //        if (entry.State == EntityState.Modified)
        //            entry.Property("RegisterDate").IsModified = false;
        //    }
        //    return base.SaveChanges();
        //}
    }
}
