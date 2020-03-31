using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Models.Relationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Collections
{

    public class PublishingCompanies<T> : List<PublishingCompany>
    {

        public void Incorporate(List<PublishingCompany> publishingCompanies)
        {

            Clear();

            foreach (PublishingCompany publishingCompany in publishingCompanies)
            {
                Add(publishingCompany);
            }

        }

        public void Genres()
        {

            ForEach(delegate (PublishingCompany publishingCompany)
            {

                foreach (GenresPublishingCompany genresPublishingCompany in publishingCompany.GenresPublishingCompanies)
                    publishingCompany.Genres.Add(genresPublishingCompany.Genre);

            });

        }

        public void Authors()
        {

            ForEach(delegate (PublishingCompany publishingCompany)
            {

                foreach (PublishingCompaniesAuthor publishingCompaniesAuthor in publishingCompany.PublishingCompaniesAuthors)
                    publishingCompany.Authors.Add(publishingCompaniesAuthor.Author);

            });

        }

        public void Series()
        {

            ForEach(delegate (PublishingCompany publishingCompany)
            {

                foreach (PublishingCompaniesSeries publishingCompaniesSeries in publishingCompany.PublishingCompaniesSeries)
                    publishingCompany.Series.Add(publishingCompaniesSeries.Series);

            });

        }

    }

}
