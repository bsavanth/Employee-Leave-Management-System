using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagement.Models;

namespace LeaveManagement.ViewModels
{
   
    public class EmployeeViewModel
    {


        public Leave leave { get; set; }
        public List<Employee> employees { get; set; }

    }


}

