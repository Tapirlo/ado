using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace Tennis
{
    public class Contesto: DbContext
    {
        public Contesto(DbContextOptions<Contesto> opzioni) : base(opzioni)
        {

        }

        public virtual DbSet<Partita> Partite { get; set; }
        public virtual DbSet<Iscrizione> Iscrizioni { get; set; }
        public virtual DbSet<Giocatore> Giocatori { get; set; }

        public static Contesto SqlServerContext()
        {
            DbContextOptionsBuilder<Contesto> builder = new DbContextOptionsBuilder<Contesto>();
            builder.UseSqlServer(DatabaseTennis.connectionString);
            return new Contesto(builder.Options);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Giocatore>().Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
            modelBuilder.Entity<Giocatore>().Property(x => x.Nickname).IsRequired();
            modelBuilder.Entity<Giocatore>().Property(x => x.DataNascita).IsRequired();
            modelBuilder.Entity<Giocatore>().Property(x => x.Livello).IsRequired();
            modelBuilder.Entity<Giocatore>().Property(x => x.Cognome).IsRequired();
            modelBuilder.Entity<Giocatore>().HasKey(x => x.Id);


            modelBuilder.Entity<Partita>().Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
            modelBuilder.Entity<Partita>().Property(x => x.Inizio).IsRequired();
            modelBuilder.Entity<Partita>().Property(x => x.Risultato).IsRequired();
            modelBuilder.Entity<Partita>().Property(x => x.Tipo).HasColumnName("tipe").IsRequired();
            modelBuilder.Entity<Partita>().Property(x => x.Fine).IsRequired();
            modelBuilder.Entity<Partita>().HasKey(x => x.Id);


            modelBuilder.Entity<Iscrizione>().Property(x => x.Giocatore).IsRequired();
            modelBuilder.Entity<Iscrizione>().Property(x => x.Partita).IsRequired();
            modelBuilder.Entity<Iscrizione>().HasKey(x => new { x.Giocatore, x.Partita });
            modelBuilder.Entity<Iscrizione>().HasOne(x => x.PartitaNavigation).WithMany(x => x.Iscrizioni).HasForeignKey(x => x.Partita).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Iscrizione>().HasOne(x => x.GiocatoreNavigation).WithMany(x => x.Iscrizioni).HasForeignKey(x => x.Giocatore).OnDelete(DeleteBehavior.Cascade);






        }
    }
}
