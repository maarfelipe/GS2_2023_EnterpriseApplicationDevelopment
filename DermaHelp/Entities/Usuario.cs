using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DermaHelp.Entities
{
    public class Usuario
    {
        [Key]
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

        //public List<Imagem> ImagemList { get; set; }

        //public List<Consulta> ConsultaList { get; set; }
    }
}
