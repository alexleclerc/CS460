using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Homework8.Models
{
    public partial class ArtWorksContext : DbContext
    {
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<Artworks> Artworks { get; set; }
        public virtual DbSet<Classifications> Classifications { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ArtWorks;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artists>(entity =>
            {
                entity.HasKey(e => e.ArtistId);

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.BirthCity)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('Unknown')");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('Anonymous')");

                entity.Property(e => e.MiddleName).HasMaxLength(100);
            });

            modelBuilder.Entity<Artworks>(entity =>
            {
                entity.HasKey(e => e.ArtworkId);

                entity.Property(e => e.ArtworkId).HasColumnName("ArtworkID");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.Title).HasDefaultValueSql("('Untitled')");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.ArtistId);
            });

            modelBuilder.Entity<Classifications>(entity =>
            {
                entity.HasKey(e => e.ClassificationId);

                entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");

                entity.Property(e => e.ArtworkId).HasColumnName("ArtworkID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.Classifications)
                    .HasForeignKey(d => d.ArtworkId);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Classifications)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_Classifications_Genre_GenreID");
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.GenreId);

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}
