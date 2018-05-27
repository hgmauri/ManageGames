namespace ManageGames.Domain.Entities
{
    public class Jogo : Entity
    {
        public string Nome { get; set; }
        public virtual Genero Genero { get; set; }

    }
}
