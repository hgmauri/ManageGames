using System;
using System.ComponentModel.DataAnnotations;

namespace ManageGames.Web.Models
{
    public class JogoVM
    {
        [Required(ErrorMessage = "O Jogo é obrigatorio")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Jogo")]
        public string Nome { get; set; }
        
        public GeneroVM Genero { get; set; }
    }
}