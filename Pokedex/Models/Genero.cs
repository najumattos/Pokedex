using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Models;

    [Table("Genero")]
    public class Genero
    {
        [Key]
        public uint Id { get; set; }
        
        [Display(Name = "Gênero", Prompt="Informe o Gênero")]
        [Required(ErrorMessage = "Informe o Gênero")]
        [StringLength(30)]
        public string Nome { get; set; }
    }
