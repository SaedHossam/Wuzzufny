using GlassDoor.ViewModels.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CityDto : GenericDto
    {
        public int CountryId { get; set; }
    }

    public class CityCreateDto
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
