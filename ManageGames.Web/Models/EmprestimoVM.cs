using System;

namespace ManageGames.Web.Models
{
    public class EmprestimoVM
    {
        public Guid Id { get; set; }
        public AmigoVM Amigo { get; set; }
        public JogoVM Jogo { get; set; }
        
    }
}