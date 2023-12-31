﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DermaHelp.Entities
{
    [Table("Medicos")]
    public class Medico
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("nome_medico")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100)]
        public required string Nome { get; set; }

        [Column("crm_medico")]
        [Required(ErrorMessage = "CRM é obrigatório.")]
        [MaxLength(13)]
        public required string Crm { get; set; }

        [Column("email_medico")]
        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email precisa ser válido")]
        [MaxLength(256)]
        public required string Email { get; set; }

        // One-to-Many relationship with Consulta
        public virtual ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    }
}