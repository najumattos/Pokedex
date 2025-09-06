using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Models;

[Table("Pokemon")]

public class Pokemon
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)] //Notação para impedir o auto incremento
    public uint Numero { get; set; }

    [Required(ErrorMessage = "Informe a Região")]
    public uint RegiaoId { get; set; }
    [ForeignKey("RegiaoId")]
    public Regiao Regiao { get; set; }

    [Required(ErrorMessage = "Informe o Gênero")]
    public uint GeneroId { get; set; }
    [ForeignKey("GeneroId")]
    public Genero Genero { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "Informe o nome")]
    public string Nome { get; set; }

    [StringLength(1000)]
    public string Descricao { get; set; }

    [Column(TypeName = "double(5,2)")]
    [Required(ErrorMessage = "Informe a altura")]
    public double Altura { get; set; }

    [Column(TypeName = "double(7,3)")]
    [Required(ErrorMessage = "Informe o peso")]
    public double Peso { get; set; }

    [StringLength(200)]
    public string Imagem { get; set; }

    [StringLength(400)]
    public string Animacao { get; set; }

    public virtual ICollection<PokemonTipo> Tipos { get; set; }
}