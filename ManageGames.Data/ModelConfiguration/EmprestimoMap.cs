using System.Data.Entity.ModelConfiguration;
using ManageGames.Domain.Entities;

namespace ManageGames.Data.ModelConfiguration
{
    public class EmprestimoMap: EntityTypeConfiguration<Emprestimo>
    {
        public EmprestimoMap()
        {
            ToTable("Emprestimo");
            HasKey(x => x.Id);
        }
    }
}
