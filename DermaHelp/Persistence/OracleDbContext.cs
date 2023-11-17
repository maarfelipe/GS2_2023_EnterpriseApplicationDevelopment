using DermaHelp.Entities;
using Microsoft.EntityFrameworkCore;

namespace DermaHelp.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<MedicoConsultorio> MedicoConsultorios { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Usuario-Imagem relationship
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Imagens)
                .WithOne(i => i.Usuario)
                .HasForeignKey(i => i.UsuarioId);

            // Configure Consulta-Usuario relationship
            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Consultas)
                .HasForeignKey(c => c.UsuarioId);

            // Configure Consultorio-Endereco relationship
            modelBuilder.Entity<Consultorio>()
                .HasOne(c => c.Endereco)
                .WithOne(e => e.Consultorio)
                .HasForeignKey<Endereco>(e => e.ConsultorioId);

            // Configure Consultorio-Consulta relationship
            modelBuilder.Entity<Consultorio>()
                .HasMany(c => c.Consultas)
                .WithOne(c => c.Consultorio)
                .HasForeignKey(c => c.ConsultorioId);

            // Configure Medico-Consulta relationship
            modelBuilder.Entity<Medico>()
                .HasMany(m => m.Consultas)
                .WithOne(c => c.Medico)
                .HasForeignKey(c => c.MedicoId);

            // Configure Medico-Consultorio many-to-many relationship
            modelBuilder.Entity<MedicoConsultorio>()
                .HasKey(mc => new { mc.MedicoId, mc.ConsultorioId });

            modelBuilder.Entity<MedicoConsultorio>()
                .HasOne(mc => mc.Medico)
                .WithMany(m => m.MedicoConsultorio)
                .HasForeignKey(mc => mc.MedicoId);

            modelBuilder.Entity<MedicoConsultorio>()
                .HasOne(mc => mc.Consultorio)
                .WithMany(c => c.MedicoConsultorio)
                .HasForeignKey(mc => mc.ConsultorioId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

