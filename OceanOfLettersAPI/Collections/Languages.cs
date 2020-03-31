using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Models.Relationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Collections
{

    public class Languages<T> : List<Language>
    {

        public void Incorporate(List<Language> languages)
        {

            Clear();

            foreach (Language language in languages)
            {
                Add(language);
            }

        }

    }

}
