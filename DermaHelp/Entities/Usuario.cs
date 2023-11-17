using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DermaHelp.Entities
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nome_usuario")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100)]
        public required string Nome { get; set; }

        [Column("cpf_usuario")]
        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(11)]
        public required string Cpf { get; set; }

        [Column("email_usuario")]
        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email precisa ser válido")]
        [MaxLength(256)]
        public required string Email { get; set; }

        [Column("senha_usuario")]
        [Required(ErrorMessage = "Senha é obrigatório.")]
        [MaxLength(60)]
        public required string Senha { get; set; }

        public virtual ICollection<Imagem> Imagens { get; set; } = new List<Imagem>();

        public virtual ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    }
}

