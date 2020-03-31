using OceanOfLettersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanOfLettersAPI.Collections
{
    public class Countries<T> : List<Country>
    {

        public void Incorporate(List<Country> countries)
        {

            Clear();

            foreach (Country country in countries)
            {
                Add(country);
            }

        }

    }
}
