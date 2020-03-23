using OceanOfLettersAPI.Context;
using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Applications
{

    public class SeriesApplication
    {

        private readonly OceanOfLettersContext Context;

        public SeriesApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

    }

}
