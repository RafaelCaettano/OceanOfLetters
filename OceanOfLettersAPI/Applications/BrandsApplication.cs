using Microsoft.EntityFrameworkCore;
using OceanOfLettersAPI.Context;
using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Utilities;
using OceanOfLettersAPI.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OceanOfLettersAPI.Models.Relationships;

namespace OceanOfLettersAPI.Applications
{

    public class BrandsApplication
    {

        private readonly OceanOfLettersContext Context;

        public BrandsApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

        public async Task<Response> Index(bool publishingCompany, bool books, bool authors, bool genres, bool series, int numBrands)
        {

            Response response = new Response();
            Brands<Brand> brands = new Brands<Brand>();

            try
            {

                if (numBrands == 0)
                {

                    brands.Incorporate(
                        await Context.Brand.OrderBy(x => x.Name)
                                           .ToListAsync()
                    );

                }
                else
                {

                    brands.Incorporate(
                        await Context.Brand.OrderBy(x => x.Name)
                                           .Take(numBrands)
                                           .ToListAsync()
                    );

                }


                if (series)
                {

                    brands.Union(
                        await Context.Brand.Include(x => x.BrandsSeries)
                                                .ThenInclude(y => y.Series)
                                           .ToListAsync()
                    );

                    brands.Series();

                }

                if (authors)
                {

                    brands.Union(
                        await Context.Brand.Include(x => x.BrandsAuthors)
                                                .ThenInclude(y => y.Author)
                                           .ToListAsync()
                    );

                    brands.Authors();

                }

                if (genres)
                {

                    brands.Union(
                        await Context.Brand.Include(x => x.GenresBrands)
                                                .ThenInclude(y => y.Genre)
                                            .ToListAsync()
                    );

                    brands.Genres();

                }

                if (publishingCompany)
                {

                    brands.Union(
                        await Context.Brand.Include(x => x.PublishingCompany)
                                           .ToListAsync()
                    );

                }

                if (books)
                {

                    brands.Union(
                        await Context.Brand.Include(x => x.Books)
                                           .ToListAsync()
                    );

                }

                response.Brands = brands;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            return response;

        }

        public async Task<Response> Store(Brand brand)
        {

            Response response = new Response
            {
                Brand = brand
            };

            try
            {

                if (!BrandExists(brand.Name))
                {
                    Context.Add(brand);
                    await Context.SaveChangesAsync();

                    response.Message = "Marca de editora cadastrada com sucesso!";
                }
                else
                {
                    response.Message = "Marca de editora já cadastrada";
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

        private bool BrandExists(string name)
        {
            return Context.Brand.Any(e => e.Name == name);
        }

    }

}
