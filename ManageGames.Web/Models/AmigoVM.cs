using System;
using System.ComponentModel.DataAnnotations;

namespace ManageGames.Web.Models
{
    public class AmigoVM
    {
        [Required(ErrorMessage = "O Amigo é obrigatorio")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatorio")]
        [StringLength(50, ErrorMessage = "O nome deve ter ate 50 Caracteres")]
        public string Nome { get; set; }
        [Required (ErrorMessage = "O Apelido é obrigatorio")]
        [StringLength(15, ErrorMessage = "O nome deve ter ate 15 Caracteres")]
        public string Apelido { get; set; }
        [Required(ErrorMessage = "A Idade é obrigatorio")]
        [Range(0, 100,ErrorMessage = "A idade tem que estar entra 0 e 100")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "O Email é obrigatorio")]
        [EmailAddress]
        public string Email { get; set; }    
    
    }
}