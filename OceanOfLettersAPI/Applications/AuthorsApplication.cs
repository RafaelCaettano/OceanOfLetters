using OceanOfLettersAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Applications
{

    public class AuthorsApplication
    {

        private readonly OceanOfLettersContext Context;

        public AuthorsApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

    }

}
