using OceanOfLettersAPI.Context;
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



    }
}
