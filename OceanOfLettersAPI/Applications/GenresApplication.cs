using OceanOfLettersAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Applications
{

    public class GenresApplication
    {

        private readonly OceanOfLettersContext Context;

        public GenresApplication(OceanOfLettersContext context)
        {
            Context = context;
        }



    }

}
