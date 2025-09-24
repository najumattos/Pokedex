using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Models;


    [Table("Regiao")]
    public class Regiao
    {
        [Key]
        public uint Id { get; set; }
        
        [Display(Name = "Região", Prompt="Informe a Região")]
        [Required(ErrorMessage = "Informe a Região")]
        [StringLength(30)]
        public string Nome { get; set; }
    }