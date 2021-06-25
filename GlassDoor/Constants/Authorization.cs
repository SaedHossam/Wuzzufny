using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.Constants
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator,
            Employee,
            Company
        }

        public const string default_username = "admin";
        public const string default_email = "admin@glassdoor.com";
        public const string default_password = "Pa$$w0rd.";
        public const Roles default_role = Roles.Administrator;
    }
}
