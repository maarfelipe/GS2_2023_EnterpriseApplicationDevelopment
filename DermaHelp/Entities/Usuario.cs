using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DermaHelp.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório.")]
        public required string Cpf { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email precisa ser válido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
        public required string Senha { get; set; }

        public virtual ICollection<Imagem> Imagens { get; set; } = new List<Imagem>();

        //public List<Consulta> ConsultaList { get; set; }
    }
}
