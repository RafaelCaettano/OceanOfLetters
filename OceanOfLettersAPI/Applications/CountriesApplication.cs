using OceanOfLettersAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Applications
{

    public class CountriesApplication
    {

        private readonly OceanOfLettersContext Context;

        public CountriesApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

    }

}
