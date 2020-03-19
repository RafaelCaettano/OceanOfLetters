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

        public virtual DbSet<Book> Books { get; set; }

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

        }

    }

}
