using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public interface IEmployeeRepository
    {

        List<Employee> GetEmployees();

        string GetName(int Id);

    }
}
