using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DermaHelp.Entities
{
    [Table("Consultorios")]
    public class Consultorio
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("nome_consultorio")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100)]
        public required string Nome { get; set; }

        [Column("cnpj_consultorio")]
        [Required(ErrorMessage = "CNPJ é obrigatório.")]
        [MaxLength(14)]
        public required string Cnpj { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();

        // One-to-One relationship with Endereco
        [ForeignKey("Endereco")]
        [Column("id_endereco")]
        public long EnderecoId { get; set; }
        public virtual required Endereco Endereco { get; set; }

        // Many-to-Many relationship with Medico
        public virtual ICollection<MedicoConsultorio> MedicoConsultorio { get; set; } = new List<MedicoConsultorio>();
    }
}