using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OceanOfLettersAPI.Models;

namespace OceanOfLettersAPI.Context
{

    public class OceanOfLettersContext : DbContext
    {

        public OceanOfLettersContext()
        {
        }

        public OceanOfLettersContext(DbContextOptions<OceanOfLettersContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<PublishingCompany> PublishingCompany { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>(entity =>
            {

                entity.ToTable("books");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasColumnName("format")
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.Synopsis)
                    .IsRequired()
                    .HasColumnName("synopsis")
                    .HasColumnType("text");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("isbn")
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("language_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Launch)
                    .HasColumnName("launch")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Pages)
                    .IsRequired()
                    .HasColumnName("pages")
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.PublishingCompanyId)
                    .HasColumnName("publishing_company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SeriesId)
                    .HasColumnName("series_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("int(11)");

            });

            modelBuilder.Entity<Author>(entity =>
            {

                entity.ToTable("authors");

                entity.HasIndex(e => e.CountryId)
                    .HasName("country_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActivityPeriod)
                    .HasColumnName("activity_period")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Biography)
                    .HasColumnName("biography")
                    .HasColumnType("text");

                entity.Property(e => e.Birth)
                    .HasColumnName("birth")
                    .HasColumnType("date");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Death)
                    .HasColumnName("death")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasColumnName("nationality")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Occupation)
                    .IsRequired()
                    .HasColumnName("occupation")
                    .HasColumnType("varchar(100)");

            });

            modelBuilder.Entity<Brand>(entity =>
            {

                entity.ToTable("brands");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.PublishingCompanyId)
                    .IsRequired()
                    .HasColumnName("publishing_company_id")
                    .HasColumnType("int(11)");

            });

            modelBuilder.Entity<Country>(entity =>
            {

                entity.ToTable("countries");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LanguageId)
                    .IsRequired()
                    .HasColumnName("language_id")
                    .HasColumnType("int(11)");

            });

            modelBuilder.Entity<Genre>(entity =>
            {

                entity.ToTable("genres");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text");

            });

            modelBuilder.Entity<Language>(entity =>
            {

                entity.ToTable("languages");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

            });

            modelBuilder.Entity<PublishingCompany>(entity =>
            {

                entity.ToTable("publishing_company");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Foundation)
                    .IsRequired()
                    .HasColumnName("foundation")
                    .HasColumnType("datetime");

                entity.Property(e => e.Founders)
                    .IsRequired()
                    .HasColumnName("founders")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Headquarters)
                    .IsRequired()
                    .HasColumnName("headquaters")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasColumnName("website")
                    .HasColumnType("varchar(100)");

            });

            modelBuilder.Entity<Series>(entity =>
            {

                entity.ToTable("series");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Synopsis)
                    .IsRequired()
                    .HasColumnName("synopsis")
                    .HasColumnType("text");

            });

        }


        public DbSet<OceanOfLettersAPI.Models.Series> Series { get; set; }


    }

}
