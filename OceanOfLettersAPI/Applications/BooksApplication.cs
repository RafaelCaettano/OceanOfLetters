﻿using OceanOfLettersAPI.Context;
using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Models.Relationships;
using OceanOfLettersAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Applications
{
    public class BooksApplication
    {

        private readonly OceanOfLettersContext Context;

        public BooksApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

        public async Task<Response> Store(Book book)
        {

            Response response = new Response
            {
                Book = book
            };

            try
            {

                if (!BookExists(book.Isbn))
                {

                    foreach (AuthorsBook authorsBook in book.AuthorsBook)
                    {

                        var wherePublishingCompaniesAuthor = Context.PublishingCompaniesAuthor.Where(x => x.PublishingCompanyId == book.PublishingCompanyId && x.AuthorId == authorsBook.AuthorId).ToList();
                        PublishingCompaniesAuthor publishingCompaniesAuthorExist = wherePublishingCompaniesAuthor.FirstOrDefault();

                        if (publishingCompaniesAuthorExist == null)
                        {
                            PublishingCompaniesAuthor publishingCompaniesAuthor = new PublishingCompaniesAuthor
                            {
                                AuthorId = authorsBook.AuthorId,
                                PublishingCompanyId = book.PublishingCompanyId
                            };

                            Context.PublishingCompaniesAuthor.Add(publishingCompaniesAuthor);
                        }

                        if (book.BrandId != null)
                        {
                            var whereBrandsAuthor = Context.BrandsAuthor.Where(x => x.BrandId == book.BrandId && x.AuthorId == authorsBook.AuthorId).ToList();
                            BrandsAuthor brandsAuthorExist = whereBrandsAuthor.FirstOrDefault();

                            if (brandsAuthorExist == null)
                            {
                                BrandsAuthor brandsAuthor = new BrandsAuthor
                                {
                                    AuthorId = authorsBook.AuthorId,
                                    BrandId = book.BrandId
                                };

                                Context.BrandsAuthor.Add(brandsAuthor);
                            }

                        }

                    }

                    if (book.SeriesId != null && book.BrandId != null)
                    {
                        var whereBrandsSeries = Context.BrandsSeries.Where(x => x.BrandId == book.BrandId && x.SeriesId == book.SeriesId).ToList();
                        BrandsSeries brandsSeriesExist = whereBrandsSeries.FirstOrDefault();

                        if (brandsSeriesExist == null)
                        {
                            BrandsSeries brandsSeries = new BrandsSeries
                            {
                                BrandId = book.BrandId,
                                SeriesId = book.SeriesId
                            };

                            Context.BrandsSeries.Add(brandsSeries);
                        }
                    }

                    foreach (GenresBook genresBook in book.GenresBooks)
                    {

                        foreach (AuthorsBook authorsBook in book.AuthorsBook)
                        {
                            var whereGenresAuthor = Context.GenresAuthor.Where(x => x.GenreId == genresBook.GenreId && x.AuthorId == authorsBook.AuthorId).ToList();
                            GenresAuthor genresAuthorExist = whereGenresAuthor.FirstOrDefault();

                            if (genresAuthorExist == null)
                            {
                                GenresAuthor genresAuthor = new GenresAuthor
                                {
                                    AuthorId = authorsBook.AuthorId,
                                    GenreId = genresBook.GenreId
                                };

                                Context.GenresAuthor.Add(genresAuthor);
                            }
                        }

                        var whereGenresPublishingCompanies = Context.GenresPublishingCompany.Where(x => x.GenreId == genresBook.GenreId && x.PublishingCompanyId == book.PublishingCompanyId).ToList();
                        GenresPublishingCompany genresPublishingCompanyExist = whereGenresPublishingCompanies.FirstOrDefault();

                        if (genresPublishingCompanyExist == null)
                        {
                            GenresPublishingCompany genresPublishingCompany = new GenresPublishingCompany
                            {
                                PublishingCompanyId = book.PublishingCompanyId,
                                GenreId = genresBook.GenreId
                            };

                            Context.GenresPublishingCompany.Add(genresPublishingCompany);
                        }

                        if (book.BrandId != null)
                        {
                            var whereGenresBrands = Context.GenresBrand.Where(x => x.GenreId == genresBook.GenreId && x.BrandId == book.BrandId).ToList();
                            GenresBrand genresBrandExist = whereGenresBrands.FirstOrDefault();

                            if (genresBrandExist == null)
                            {
                                GenresBrand genresBrand = new GenresBrand
                                {
                                    BrandId = book.BrandId,
                                    GenreId = genresBook.GenreId
                                };

                                Context.GenresBrand.Add(genresBrand);
                            }

                        }

                        if (book.SeriesId != null)
                        {
                            var whereGenresSeries = Context.GenresSeries.Where(x => x.GenreId == genresBook.GenreId && x.SeriesId == book.SeriesId).ToList();
                            GenresSeries genresSeriesExist = whereGenresSeries.FirstOrDefault();

                            if (genresSeriesExist == null)
                            {
                                GenresSeries genresSeries = new GenresSeries
                                {
                                    GenreId = genresBook.GenreId,
                                    SeriesId = book.SeriesId
                                };

                                Context.GenresSeries.Add(genresSeries);
                            }
                        }

                    }

                    if (book.SeriesId != null)
                    {
                        var wherePublishingCompaniesSeries = Context.PublishingCompaniesSeries.Where(x => x.SeriesId == book.SeriesId && x.PublishingCompanyId == book.PublishingCompanyId).ToList();
                        PublishingCompaniesSeries publishingCompaniesSeriesExist = wherePublishingCompaniesSeries.FirstOrDefault();

                        if (publishingCompaniesSeriesExist == null)
                        {
                            PublishingCompaniesSeries publishingCompaniesSeries = new PublishingCompaniesSeries
                            {
                                SeriesId = book.SeriesId,
                                PublishingCompanyId = book.PublishingCompanyId
                            };

                            Context.PublishingCompaniesSeries.Add(publishingCompaniesSeries);
                        } 
                    }

                    Context.Add(book);
                    await Context.SaveChangesAsync();

                    response.Message = "Livro cadastrado com sucesso!";
                }
                else
                {
                    response.Message = "Livro já cadastrado";
                    response.BadRequest = true;
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            return response;

        }

        private bool BookExists(string isbn)
        {
            return Context.Book.Any(e => e.Isbn == isbn);
        }

    }
}
