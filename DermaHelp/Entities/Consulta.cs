using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DermaHelp.Entities
{
    [Table("Consultas")]
    public class Consulta
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("data_consulta")]
        public DateTime DataHora { get; set; }

        [ForeignKey("Usuario")]
        [Column("id_usuario")]
        public int UsuarioId { get; set; }
        public virtual required Usuario Usuario { get; set; }

        [ForeignKey("Medico")]
        [Column("id_medico")]
        public long MedicoId { get; set; }
        public virtual required Medico Medico { get; set; }

        [ForeignKey("Consultorio")]
        [Column("id_consultorio")]
        public long ConsultorioId { get; set; }
        public virtual required Consultorio Consultorio { get; set; }
    }
}
