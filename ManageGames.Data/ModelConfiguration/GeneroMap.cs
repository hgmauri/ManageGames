using System.Data.Entity.ModelConfiguration;
using ManageGames.Domain.Entities;

namespace ManageGames.Data.ModelConfiguration
{
    class GeneroMap : EntityTypeConfiguration<Genero>
    {
        public GeneroMap()
        {
            ToTable("Genero");
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired().HasMaxLength(50);
        }
    }
}
