using System.Data.Entity;
using ManageGames.Data.ModelConfiguration;
using ManageGames.Domain;
using ManageGames.Domain.Entities;

namespace ManageGames.Data.Contexts
{
    public class ManageGamesDataContext : DbContext
    {
        public ManageGamesDataContext() : base(Runtime.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Amigo> Amigo { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AmigoMap());
            modelBuilder.Configurations.Add(new GeneroMap());
            modelBuilder.Configurations.Add(new JogoMap());
            modelBuilder.Configurations.Add(new EmprestimoMap());
        }
    }
}
