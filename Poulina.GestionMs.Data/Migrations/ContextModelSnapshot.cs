﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poulina.GestionMs.Data;

namespace Poulina.GestionMs.Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Categorie", b =>
                {
                    b.Property<Guid>("IdCategorie")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("IdCategorie");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Comm_Vote", b =>
                {
                    b.Property<Guid>("IDCVote")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("IdCom");

                    b.Property<Guid>("IdVote");

                    b.HasKey("IDCVote");

                    b.HasIndex("IdCom");

                    b.HasIndex("IdVote");

                    b.ToTable("Comm_Vote");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Commentaire", b =>
                {
                    b.Property<Guid>("IdCom")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid>("IdQuestion");

                    b.HasKey("IdCom");

                    b.HasIndex("IdQuestion");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Dem_Categorie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("IdCategorie");

                    b.Property<Guid>("IdInf");

                    b.HasKey("Id");

                    b.HasIndex("IdCategorie");

                    b.HasIndex("IdInf");

                    b.ToTable("Dem_Categorie");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Demande_information", b =>
                {
                    b.Property<Guid>("IdInf")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.HasKey("IdInf");

                    b.ToTable("demandes");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Vote", b =>
                {
                    b.Property<Guid>("IdVote")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Note");

                    b.HasKey("IdVote");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.sous_categorie", b =>
                {
                    b.Property<Guid>("IdSC")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategorieFK");

                    b.Property<string>("Label");

                    b.HasKey("IdSC");

                    b.HasIndex("CategorieFK");

                    b.ToTable("Sous_Categories");
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Comm_Vote", b =>
                {
                    b.HasOne("Poulina.GestionMs.Domain.Models.Commentaire", "Commentaire")
                        .WithMany("Comm_Votes")
                        .HasForeignKey("IdCom")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Poulina.GestionMs.Domain.Models.Vote", "Vote")
                        .WithMany("Comm_Votes")
                        .HasForeignKey("IdVote")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Commentaire", b =>
                {
                    b.HasOne("Poulina.GestionMs.Domain.Models.Demande_information", "demande_Information")
                        .WithMany("commentaires")
                        .HasForeignKey("IdQuestion")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.Dem_Categorie", b =>
                {
                    b.HasOne("Poulina.GestionMs.Domain.Models.Categorie", "Categories")
                        .WithMany("Dem_Categories")
                        .HasForeignKey("IdCategorie")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Poulina.GestionMs.Domain.Models.Demande_information", "Demande_information")
                        .WithMany("Dem_Categories")
                        .HasForeignKey("IdInf")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Poulina.GestionMs.Domain.Models.sous_categorie", b =>
                {
                    b.HasOne("Poulina.GestionMs.Domain.Models.Categorie", "Categorie")
                        .WithMany("Sous_categories")
                        .HasForeignKey("CategorieFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
