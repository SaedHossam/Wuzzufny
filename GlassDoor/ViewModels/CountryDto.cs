using GlassDoor.ViewModels.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CountryDto : GenericDto
    {
        // TODO: Make viewmodel with city id and name only(remove countryId)
        public IEnumerable<CityDto> Cities { get; set; }
    }

    public class CountryCreateDto
    {
        public string Name { get; set; }
    }
}
