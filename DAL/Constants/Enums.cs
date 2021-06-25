using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public static class Enums
    {
        public enum Gender { Male, Female }

        public enum MilitaryStatus { NotApplicable, Exempted, Completed, Postponed }

        public enum CurrentJobStatus { Unemployed, Looking, Interested, NotLooking }

        public enum CompanyRequestStatus { UnderReview, Accepted, Rejected }
        public enum ApplicationStatus { Applied, Viewed, InConsideration, Rejected, Hired }
    }
}

