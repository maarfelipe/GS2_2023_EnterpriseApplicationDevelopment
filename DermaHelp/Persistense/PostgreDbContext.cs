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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // 1:1 Endereco-Consultorio relationship  
            modelBuilder.Entity<Endereco>()
               .HasKey(e => e.Id);

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Consultorio)
                .WithOne(c => c.Endereco)
                .HasForeignKey<Consultorio>(c => c.EnderecoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}
