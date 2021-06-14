using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public IEnumerable< Employee> GetEmployeeData();
        public  Employee GetEmployeeDataById(int id);
        public Employee GetJobCateogyForOneEmp(int id);
        public Employee GetEmpSkills(int id);
        public Employee GetEmpJobTypes(int id);
        public Employee GetEmpLanguages(int id);
        public Employee GetEmpLinks(int id);
        public Employee GetEmpData(int id);


        public Employee GetEmployeeSkills(int id);
        
    }
}
