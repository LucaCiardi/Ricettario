using System.ComponentModel.DataAnnotations;
using Utility;
namespace Entities
{
    public class Ricetta : Entity
    {
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(200, ErrorMessage = "Il nome non può superare i 200 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "La categoria è obbligatoria")]
        [StringLength(50, ErrorMessage = "La categoria non può superare i 50 caratteri")]
        public string Categoria { get; set; }

        [StringLength(100, ErrorMessage = "Il tipo di cucina non può superare i 100 caratteri")]
        public string? TipoCucina { get; set; }

        [Range(1, 480, ErrorMessage = "Il tempo deve essere tra 1 e 480 minuti")]
        public int TempoPreparazione { get; set; }

        [Required(ErrorMessage = "Gli ingredienti sono obbligatori")]
        public string Ingredienti { get; set; }

        [Required(ErrorMessage = "Le istruzioni sono obbligatorie")]
        public string Istruzioni { get; set; }

        [StringLength(20, ErrorMessage = "La difficoltà non può superare i 20 caratteri")]
        public string? Difficolta { get; set; }

        public Ricetta() { }
    }
}