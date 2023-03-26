using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class EmployeeRepo
    {
        static Empcontext empcontext;
        static EmployeeRepo()
        {
            empcontext = new Empcontext();
        }

        public static List<Employee> Get()
        {
            return empcontext.Employees.ToList();
        }
        public static Employee Get(int id)
        {
            return empcontext.Employees.Find(id);
        }
        public static bool Create(Employee employee)
        {
            empcontext.Employees.Add(employee);
            return empcontext.SaveChanges() > 0;

        }
        public static bool Update(Employee employee)
        {
            var exemp = empcontext.Employees.Find(employee.Id);
            empcontext.Entry(exemp).CurrentValues.SetValues(employee);
            return empcontext.SaveChanges() > 0;

        }
        public static bool Delete(int id)
        {
            var exemp = Get(id);
            empcontext.Employees.Remove(exemp);
            return empcontext.SaveChanges() > 0;

        }

    }
}
