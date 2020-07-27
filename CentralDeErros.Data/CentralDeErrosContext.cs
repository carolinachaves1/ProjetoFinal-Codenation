using CentralDeErros.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CentralDeErros.Data
{
    public class CentralDeErrosContext : IdentityDbContext
    {
        public DbSet<Error> Errors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Level> Levels { get; set; }

        public CentralDeErrosContext(DbContextOptions<CentralDeErrosContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=CentralDeErros;User Id=sa;Password=@carol0950");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(x => x.Name).IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Category>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Category>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>()
                .HasMany(x => x.Errors)
                .WithOne(e => e.Category)
                .IsRequired();

            modelBuilder.Entity<Level>()
               .Property(x => x.Name).IsRequired()
               .HasMaxLength(100);
            modelBuilder.Entity<Level>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Level>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Level>()
                .HasMany(x => x.Errors)
                .WithOne(e => e.Level)
                .IsRequired();

            modelBuilder.Entity<Error>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Error>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Error>()
                .Property(x => x.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Error>()
                .HasOne(x => x.Level)
                .WithMany(e => e.Errors)
                .IsRequired();
            modelBuilder.Entity<Error>()
               .HasOne(x => x.Category)
               .WithMany(e => e.Errors)
               .IsRequired();
        }
    }
}
