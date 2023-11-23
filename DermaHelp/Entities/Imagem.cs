using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DermaHelp.Entities
{
    [Table("Imagens")]
    public class Imagem
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("data_hora")]
        public DateTime DataHora { get; set; }

        [Column("image_data")]
        [MaxLength(500)]
        public required string ImageData { get; set; }

        [Column("resultado_imagem")]
        [MaxLength(500)]
        public string? Resultado { get; set; }

        [ForeignKey("Usuario")]
        [Column("id_usuario")]
        public int UsuarioId { get; set; }
        public virtual required Usuario Usuario { get; set; }
    }
}