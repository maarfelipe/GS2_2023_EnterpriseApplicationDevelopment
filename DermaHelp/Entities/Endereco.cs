using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DermaHelp.Entities
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("logradouro")]
        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        [MaxLength(100)]
        public required string Logradouro { get; set; }

        [Column("numero")]
        [Required(ErrorMessage = "Numero é obrigatório.")]
        public int Numero { get; set; }

        [Column("complemento")]
        [MaxLength(40)]
        public string? Complemento { get; set; }

        [Column("cidade")]
        [Required(ErrorMessage = "Cidade é obrigatório.")]
        [MaxLength(40)]
        public required string Cidade { get; set; }

        [Column("estado")]
        [Required(ErrorMessage = "Estado é obrigatório.")]
        [MaxLength(40)]
        public required string Estado { get; set; }

        [Column("cep")]
        [Required(ErrorMessage = "CEP é obrigatório.")]
        public required string Cep { get; set; }

        // One-to-One relationship with Consultorio
        [ForeignKey("Consultorio")]
        [Column("id_consultorio")]
        public long? ConsultorioId { get; set; }
        public virtual Consultorio? Consultorio { get; set; }
    }
}
