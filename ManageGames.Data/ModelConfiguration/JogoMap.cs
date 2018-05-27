using System.Data.Entity.ModelConfiguration;
using ManageGames.Domain.Entities;

namespace ManageGames.Data.ModelConfiguration
{
    class JogoMap : EntityTypeConfiguration<Jogo>
    {
        public JogoMap()
        {
            ToTable("Jogo");
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired().HasMaxLength(50);
            HasRequired(x => x.Genero);
        }
    }
}
