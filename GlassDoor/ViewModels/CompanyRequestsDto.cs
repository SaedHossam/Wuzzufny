using GlassDoor.ViewModels.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CompanyRequestsDto : GenericDto
    {
        public string Industry { get; set; }
        public string Size { get; set; }

    }

    public class CompanyRequestDto : GenericDto
    {
        public string Industry { get; set; }
        public string Size { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class CompanyRequestStatusDto
    {
        public int Id { get; set; }
        public bool Response { get; set; }
    }

}
