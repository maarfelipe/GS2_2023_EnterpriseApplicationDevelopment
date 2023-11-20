using DermaHelp.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace DermaHelp.Persistense
{
    public class PostgreDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        //public DbSet<Imagem> Imagem { get; set; }
        //public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Consultorio> Consultorio { get; set; }
        //public DbSet<Medico> Medico { get; set; }
        //public DbSet<MedicoConsultorio> MedicoConsultorio { get; set; }


        public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// 1:N Usuario-Imagem relationship
            //modelBuilder.Entity<Imagem>()
            //    .HasKey(i => i.Id);

            //modelBuilder.Entity<Usuario>()
            //    .HasMany(u => u.Imagens)
            //    .WithOne(i => i.Usuario)
            //    .HasForeignKey(i => i.UsuarioId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //    // 1:N Usuario-Consulta relationship
            //    modelBuilder.Entity<Consulta>()
            //        .HasKey(c => c.Id);

            //    modelBuilder.Entity<Usuario>()
            //        .HasMany(u => u.Consultas)
            //        .WithOne(c => c.Usuario)
            //        .HasForeignKey(c => c.UsuarioId)
            //        .OnDelete(DeleteBehavior.Cascade);

            //    // 1:N Consultorio-Consulta relationship
            //    modelBuilder.Entity<Consultorio>()
            //        .HasKey(c => c.Id);

            //    modelBuilder.Entity<Consulta>()
            //        .HasOne(c => c.Consultorio)
            //        .WithMany(c => c.Consultas)
            //        .HasForeignKey(c => c.ConsultorioId)
            //        .IsRequired(true) // Assuming Consulta must have a Consultorio
            //        .OnDelete(DeleteBehavior.Restrict);

            // 1:1 Endereco-Consultorio relationship  
            modelBuilder.Entity<Endereco>()
               .HasKey(e => e.Id);

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Consultorio)
                .WithOne(c => c.Endereco)
                .HasForeignKey<Consultorio>(c => c.EnderecoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //    // 1:1 Consulta-Medico relationship  
            //    modelBuilder.Entity<Medico>()
            //        .HasKey(m => m.Id);

            //    modelBuilder.Entity<Consulta>()
            //        .HasOne(c => c.Medico)
            //        .WithMany(m => m.Consultas)
            //        .HasForeignKey(c => c.MedicoId)
            //        .IsRequired(true) // Assuming Consulta must have a Medico
            //        .OnDelete(DeleteBehavior.Restrict); // This line specifies that deleting a Medico will not delete associated Consultas

            //    // N:N Medico-Consultorio relationship
            //    modelBuilder.Entity<MedicoConsultorio>()
            //        .HasKey(mc => new { mc.MedicoId, mc.ConsultorioId });

            //    modelBuilder.Entity<MedicoConsultorio>()
            //        .HasOne(mc => mc.Medico)
            //        .WithMany(m => m.MedicoConsultorio)
            //        .HasForeignKey(mc => mc.MedicoId)
            //        .IsRequired(false);

            //    modelBuilder.Entity<MedicoConsultorio>()
            //        .HasOne(mc => mc.Consultorio)
            //        .WithMany(c => c.MedicoConsultorio)
            //        .HasForeignKey(mc => mc.ConsultorioId)
            //        .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }

    }
}
