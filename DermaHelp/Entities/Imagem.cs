using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DermaHelp.Entities
{
    public class Imagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Data { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual required Usuario Usuario { get; set; }
    }
}
