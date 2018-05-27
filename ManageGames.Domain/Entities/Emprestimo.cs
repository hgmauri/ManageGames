namespace ManageGames.Domain.Entities
{
    public class Emprestimo:Entity
    {
        public virtual Amigo Amigo { get; set; }
        public virtual Jogo Jogo { get; set; }
    }
}
