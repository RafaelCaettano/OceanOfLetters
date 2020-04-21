using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Models.Relationships;

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

        public DbSet<Author> Author { get; set; }
        public DbSet<AuthorsBook> AuthorsBook { get; set; }
        public DbSet<AuthorsSeries> AuthorsSeries { get; set; }
        public DbSet<GenresAuthor> GenresAuthor { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<GenresBook> GenresBook { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<PublishingCompany> PublishingCompany { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<PublishingCompaniesAuthor> PublishingCompaniesAuthor { get; set; }
        public DbSet<GenresPublishingCompany> GenresPublishingCompany { get; set; }
        public DbSet<PublishingCompaniesSeries> PublishingCompaniesSeries { get; set; }
        public DbSet<BrandsAuthor> BrandsAuthor { get; set; }
        public DbSet<GenresBrand> GenresBrand { get; set; }
        public DbSet<BrandsSeries> BrandsSeries { get; set; }
        public DbSet<GenresSeries> GenresSeries { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<Avatar> Avatar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

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

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("authors_ibfk_1");

                entity.HasIndex(e => e.AvatarId)
                    .HasName("avatar_id");

                entity.Property(e => e.AvatarId)
                    .HasColumnName("avatar_id")
                    .HasColumnType("int(11)");

                entity.HasOne(b => b.Avatar)
                   .WithOne(i => i.Author)
                   .HasForeignKey<Author>(b => b.AvatarId);

            });

            modelBuilder.Entity<BrandsAuthor>(entity =>
            {
                entity.ToTable("brands_author");

                entity.HasIndex(e => e.AuthorId)
                    .HasName("brands_author_ibfk_1");

                entity.HasIndex(e => e.BrandId)
                    .HasName("brand_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BrandsAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("brands_author_ibfk_1");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.BrandsAuthors)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("brands_author_ibfk_2");
            });

            modelBuilder.Entity<GenresBrand>(entity =>
            {
                entity.ToTable("genres_brand");

                entity.HasIndex(e => e.GenreId)
                    .HasName("genre_id");

                entity.HasIndex(e => e.BrandId)
                    .HasName("brand_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.GenresBrands)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("genres_brand_ibfk_2");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.GenresBrands)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("genres_brand_ibfk_1");
            });

            modelBuilder.Entity<Cover>(entity =>
            {
                entity.ToTable("covers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(100)");

            });

            modelBuilder.Entity<Avatar>(entity =>
            {
                entity.ToTable("avatars");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(100)");

            });

            modelBuilder.Entity<GenresSeries>(entity =>
            {
                entity.ToTable("genres_series");

                entity.HasIndex(e => e.GenreId)
                    .HasName("genre_id");

                entity.HasIndex(e => e.SeriesId)
                    .HasName("series_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SeriesId)
                    .HasColumnName("series_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.GenresSeries)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("genres_series_ibfk_1");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.GenresSeries)
                    .HasForeignKey(d => d.SeriesId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("genres_series_ibfk_2");
            });

            modelBuilder.Entity<BrandsSeries>(entity =>
            {
                entity.ToTable("brands_series");

                entity.HasIndex(e => e.SeriesId)
                    .HasName("series_id");

                entity.HasIndex(e => e.BrandId)
                    .HasName("brand_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SeriesId)
                    .HasColumnName("series_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.BrandsSeries)
                    .HasForeignKey(d => d.SeriesId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("brands_series_ibfk_2");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.BrandsSeries)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("brands_series_ibfk_1");
            });

            modelBuilder.Entity<AuthorsBook>(entity =>
            {
                entity.ToTable("authors_book");

                entity.HasIndex(e => e.AuthorId)
                    .HasName("author_id");

                entity.HasIndex(e => e.BookId)
                    .HasName("book_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorsBooks)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("authors_book_ibfk_1");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorsBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("authors_book_ibfk_2");
            });

            modelBuilder.Entity<AuthorsSeries>(entity =>
            {
                entity.ToTable("authors_series");

                entity.HasIndex(e => e.AuthorId)
                    .HasName("author_id");

                entity.HasIndex(e => e.SeriesId)
                    .HasName("series_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SeriesId)
                    .HasColumnName("series_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorsSeries)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("authors_series_ibfk_1");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.AuthorsSeries)
                    .HasForeignKey(d => d.SeriesId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("authors_series_ibfk_2");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CoverId)
                    .HasColumnName("cover_id")
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

                entity.HasOne(d => d.Series)
                   .WithMany(p => p.Books)
                   .HasForeignKey(d => d.SeriesId)
                   .HasConstraintName("book_genre");

                entity.HasOne(d => d.Language)
                   .WithMany(p => p.Books)
                   .HasForeignKey(d => d.LanguageId)
                   .HasConstraintName("books_ibfk_2");

                entity.HasOne(d => d.Country)
                   .WithMany(p => p.Books)
                   .HasForeignKey(d => d.CountryId)
                   .HasConstraintName("books_ibfk_3");

                entity.HasOne(d => d.PublishingCompany)
                   .WithMany(p => p.Books)
                   .HasForeignKey(d => d.PublishingCompanyId)
                   .HasConstraintName("books_ibfk_4");

                entity.HasOne(d => d.Brand)
                   .WithMany(p => p.Books)
                   .HasForeignKey(d => d.BrandId)
                   .HasConstraintName("books_ibfk_5");

                entity.HasOne(b => b.Cover)
                   .WithOne(i => i.Book)
                   .HasForeignKey<Book>(b => b.CoverId);

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

                entity.Property(e => e.CoverId)
                    .HasColumnName("cover_id")
                    .HasColumnType("int(11)");

                entity.HasOne(b => b.Cover)
                   .WithOne(i => i.Series)
                   .HasForeignKey<Series>(b => b.CoverId);

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
                
                entity.HasIndex(e => e.AvatarId)
                     .HasName("avatar_id");

                entity.Property(e => e.AvatarId)
                    .HasColumnName("avatar_id")
                    .HasColumnType("int(11)");

                entity.HasOne(b => b.Avatar)
                   .WithOne(i => i.Genre)
                   .HasForeignKey<Genre>(b => b.AvatarId);

            });

            modelBuilder.Entity<GenresBook>(entity =>
            {
                entity.ToTable("genres_book");

                entity.HasIndex(e => e.BookId)
                    .HasName("book_id");

                entity.HasIndex(e => e.GenreId)
                    .HasName("genre_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.GenresBooks)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("genres_book_ibfk_2");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.GenresBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("genres_book_ibfk_1");
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

                entity.HasOne(d => d.Language)
                  .WithMany(p => p.Countries)
                  .HasForeignKey(d => d.LanguageId)
                  .HasConstraintName("contries_ibfk_1");
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
                
                entity.HasIndex(e => e.AvatarId)
                     .HasName("avatar_id");

                entity.Property(e => e.AvatarId)
                    .HasColumnName("avatar_id")
                    .HasColumnType("int(11)");

                entity.HasOne(b => b.Avatar)
                   .WithOne(i => i.PublishingCompany)
                   .HasForeignKey<PublishingCompany>(b => b.AvatarId);

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

                entity.HasOne(d => d.PublishingCompany)
                  .WithMany(p => p.Brands)
                  .HasForeignKey(d => d.PublishingCompanyId)
                  .HasConstraintName("brands_ibfk_1");

                entity.HasIndex(e => e.AvatarId)
                     .HasName("avatar_id");

                entity.Property(e => e.AvatarId)
                    .HasColumnName("avatar_id")
                    .HasColumnType("int(11)");

                entity.HasOne(b => b.Avatar)
                   .WithOne(i => i.Brand)
                   .HasForeignKey<Brand>(b => b.AvatarId);
            });

            modelBuilder.Entity<PublishingCompaniesAuthor>(entity =>
            {
                entity.ToTable("publishing_companies_author");

                entity.HasIndex(e => e.AuthorId)
                    .HasName("author_id");

                entity.HasIndex(e => e.PublishingCompanyId)
                    .HasName("publishing_company_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PublishingCompanyId)
                    .HasColumnName("publishing_company_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.PublishingCompaniesAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("publishing_companies_author_ibfk_1");

                entity.HasOne(d => d.PublishingCompany)
                    .WithMany(p => p.PublishingCompaniesAuthors)
                    .HasForeignKey(d => d.PublishingCompanyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("publishing_companies_author_ibfk_2");
            });

            modelBuilder.Entity<GenresAuthor>(entity =>
            {
                entity.ToTable("genres_author");

                entity.HasIndex(e => e.AuthorId)
                    .HasName("author_id");

                entity.HasIndex(e => e.GenreId)
                    .HasName("genre_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.GenresAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("genres_author_ibfk_1");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.GenresAuthors)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("genres_author_ibfk_2");
            });

            modelBuilder.Entity<GenresPublishingCompany>(entity =>
            {
                entity.ToTable("genres_publishing_company");

                entity.HasIndex(e => e.PublishingCompanyId)
                    .HasName("publishing_company_id");

                entity.HasIndex(e => e.GenreId)
                    .HasName("genre_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PublishingCompanyId)
                    .HasColumnName("publishing_company_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.GenresPublishingCompanies)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("genres_publishing_company_ibfk_1");

                entity.HasOne(d => d.PublishingCompany)
                    .WithMany(p => p.GenresPublishingCompanies)
                    .HasForeignKey(d => d.PublishingCompanyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("genres_publishing_company_ibfk_2");
            });

            modelBuilder.Entity<PublishingCompaniesSeries>(entity =>
            {
                entity.ToTable("publishing_companies_series");

                entity.HasIndex(e => e.SeriesId)
                    .HasName("series_id");

                entity.HasIndex(e => e.PublishingCompanyId)
                    .HasName("publishing_company_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SeriesId)
                    .HasColumnName("series_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PublishingCompanyId)
                    .HasColumnName("publishing_company_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.PublishingCompaniesSeries)
                    .HasForeignKey(d => d.SeriesId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("publishing_companies_series_ibfk_2");

                entity.HasOne(d => d.PublishingCompany)
                    .WithMany(p => p.PublishingCompaniesSeries)
                    .HasForeignKey(d => d.PublishingCompanyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("publishing_companies_series_ibfk_1");
            });

        }

    }

}
