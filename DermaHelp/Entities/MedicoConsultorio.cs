using System.ComponentModel.DataAnnotations.Schema;

namespace DermaHelp.Entities
{
    [Table("MedicosConsultorios")]
    public class MedicoConsultorio
    {
        [Column("id_medico")]
        public long? MedicoId { get; set; }
        public virtual Medico? Medico { get; set; }

        [Column("id_consultorio")]
        public long? ConsultorioId { get; set; }
        public virtual Consultorio? Consultorio { get; set; }
    }
}