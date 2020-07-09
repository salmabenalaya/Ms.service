using Microsoft.EntityFrameworkCore;
using Poulina.GestionMs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionMs.Data
{
   public class Context : DbContext
    {
        public Context(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Demande_information> demandes { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<sous_categorie> Sous_Categories { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public Comm_Vote Comm_Votes { get; set; }
        public Dem_Categorie Dem_Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commentaire>(entity => entity.HasKey(d => d.IdCom));
            modelBuilder.Entity<Demande_information>(entity => entity.HasKey(d => d.IdInf));
            modelBuilder.Entity<Vote>(entity => entity.HasKey(d => d.IdVote));
            modelBuilder.Entity<sous_categorie>(entity => entity.HasKey(d => d.IdSC));
            modelBuilder.Entity<Categorie>(entity => entity.HasKey(d => d.IdCategorie));
            modelBuilder.Entity<Comm_Vote>(entity => entity.HasKey(d => d.IDCVote));
            modelBuilder.Entity<Dem_Categorie>(entity => entity.HasKey(d => d.Id));

            modelBuilder.Entity<sous_categorie>()
                 .HasOne(e => e.Categorie)
                  .WithMany(s => s.Sous_categories)
                  .HasForeignKey(p => p.CategorieFK); //one to many


            modelBuilder.Entity<Commentaire>()
                .HasOne(e => e.demande_Information)
                 .WithMany(s => s.commentaires)
                 .HasForeignKey(p => p.IdQuestion); //one to many



            modelBuilder.Entity<Comm_Vote>()
               .HasOne(e => e.Commentaire)
               .WithMany(s => s.Comm_Votes)
                .HasForeignKey(p => p.IdCom); //one to many
            modelBuilder.Entity<Comm_Vote>()
               .HasOne(e => e.Vote)
               .WithMany(s => s.Comm_Votes)
                .HasForeignKey(p => p.IdVote);

            modelBuilder.Entity<Dem_Categorie>()
          .HasOne(e => e.Demande_information)
          .WithMany(s => s.Dem_Categories)
           .HasForeignKey(p => p.IdInf); //one to many
            modelBuilder.Entity<Dem_Categorie>()
               .HasOne(e => e.Categories)
               .WithMany(s => s.Dem_Categories)
                .HasForeignKey(p => p.IdCategorie);























            //      modelBuilder.Entity<sous_categorie>()
            //         .HasOne(e => e.Categorie)
            //         .WithMany(s => s.Sous_categories)
            //          .HasForeignKey(p => p.CategorieFK); //one to many

            //      modelBuilder.Entity<Comm_Info>()
            //     .HasOne(e => e.Commentaires)
            //     .WithMany(s => s.Comm_Infos)
            //      .HasForeignKey(p => p.IdCom); //many to many

            //      modelBuilder.Entity<Comm_Info>()
            //    .HasOne(e => e.Demande)
            //    .WithMany(s => s.Comm_Infos)
            //     .HasForeignKey(p => p.IdInf); //many to many
            //      base.OnModelCreating(modelBuilder);


            //      modelBuilder.Entity<Comm_Vote>()
            //.HasOne(e => e.Commentaires)
            //.WithMany(s => s.Comm_Votes)
            // .HasForeignKey(p => p.IdCom); //many to many

            //      modelBuilder.Entity<Comm_Vote>()
            //    .HasOne(e => e.Votes)
            //    .WithMany(s => s.Comm_Votes)
            //     .HasForeignKey(p => p.IdCVote); //many to many
            //      base.OnModelCreating(modelBuilder);

            //      modelBuilder.Entity<Dem_Categorie>()
            //.HasOne(e => e.Categories)
            //.WithMany(s => s.Dem_Categories)
            // .HasForeignKey(p => p.FK_Categorie); //many to many

            //      modelBuilder.Entity<Dem_Categorie>()
            //    .HasOne(e => e.Demandes)
            //    .WithMany(s => s.Dem_Categories)
            //     .HasForeignKey(p => p.FK_DemandeInfo); //many to many
            //      base.OnModelCreating(modelBuilder);



        }
    }
}