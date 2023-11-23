using DermaHelp.Entities;
using Microsoft.EntityFrameworkCore;

namespace DermaHelp.Persistense
{
    public class PostgreDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Consultorio> Consultorio { get; set; }
        public DbSet<Medico> Medico { get; set; }

        public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options) { }
    }
}
