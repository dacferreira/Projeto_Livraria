using Projeto_Livraria.Infraestrutura.Data.Migrations;
using System.Data.Entity.Migrations;

namespace Projeto_Livraria.Infraestrutura.Data.Context
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context.ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.ModelContext context)
        {
            var database = new SeedDatabase();
            database.Seed(context);
        }
    }
}
