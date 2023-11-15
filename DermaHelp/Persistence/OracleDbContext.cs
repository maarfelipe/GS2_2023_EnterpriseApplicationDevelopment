using DermaHelp.Entities;
using Microsoft.EntityFrameworkCore;

namespace DermaHelp.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        //public DbSet<Consulta> Consultas { get; set; }
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }
    }
}

