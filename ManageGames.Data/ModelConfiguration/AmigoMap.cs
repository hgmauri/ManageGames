using System.Data.Entity.ModelConfiguration;
using ManageGames.Domain.Entities;

namespace ManageGames.Data.ModelConfiguration
{

    public class AmigoMap : EntityTypeConfiguration<Amigo>
    {
        public AmigoMap()
        {
            ToTable("Amigo");
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired().HasMaxLength(160);
        }
    }
}
