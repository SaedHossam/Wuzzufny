using GlassDoor.ViewModels.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CurrencyDto : GenericDto
    {
        public string Symbol { get; set; }
        public string Code { get; set; }
    }
    public class CurrencyCreateDto
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Code { get; set; }
    }

}
