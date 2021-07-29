using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class EmployeeRepository:IEmployeeRepository
    {
        EmployeeContext _context;


        public EmployeeRepository(EmployeeContext context)
        {
            this._context = context;
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employee.ToList();
        }

        public string GetName(int Id)
        {
           Employee emp = _context.Employee.Where(employee => employee.ID == Id).FirstOrDefault();
            return emp.Name;
        }
    }
}
