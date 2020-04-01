using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Models.Relationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Collections
{

    public class Serie<T> : List<Series>
    {

        public void Incorporate(List<Series> series)
        {

            Clear();

            foreach (Series serie in series)
            {
                Add(serie);
            }

        }

        public void Genres()
        {

            ForEach(delegate (Series series)
            {

                foreach (GenresSeries genresSeries in series.GenresSeries)
                    series.Genres.Add(genresSeries.Genre);

            });

        }

        public void Authors()
        {

            ForEach(delegate (Series series)
            {

                foreach (AuthorsSeries authorsSeries in series.AuthorsSeries)
                    series.Authors.Add(authorsSeries.Author);

            });

        }

        public void Brands()
        {

            ForEach(delegate (Series series)
            {

                foreach (BrandsSeries brandsSeries in series.BrandsSeries)
                    series.Brands.Add(brandsSeries.Brand);

            });

        }

        public void PublishingCompanies()
        {

            ForEach(delegate (Series series)
            {

                foreach (PublishingCompaniesSeries publishingCompaniesSeries in series.PublishingCompaniesSeries)
                    series.PublishingCompanies.Add(publishingCompaniesSeries.PublishingCompany);

            });

        }

    }

}
