using System;
using System.ComponentModel.DataAnnotations;

namespace ManageGames.Web.Models
{
    public class GeneroVM
    {
        [Required(ErrorMessage = "O genero é obrigatorio.")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Genero")]
        public String Nome { get; set; }
    }
}