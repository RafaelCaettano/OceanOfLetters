using OceanOfLettersAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Applications
{

    public class LanguagesApplication
    {

        private readonly OceanOfLettersContext Context;

        public LanguagesApplication(OceanOfLettersContext context)
        {
            Context = context;
        }

    }

}
