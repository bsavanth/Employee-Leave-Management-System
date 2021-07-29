using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagement.Models; 
namespace LeaveManagement.ViewModels
{
    public class EmployeeNameView
    {
        IEmployeeRepository empRepo;
        public Leave leave{get; set;} 

        public string name { get; set; }

        public EmployeeNameView(IEmployeeRepository rep)
        {
            this.empRepo = rep;
            this.leave = null;
            this.name = "";
        }

        public EmployeeNameView(Leave lv, IEmployeeRepository rep)
        {
            this.empRepo = rep;
            this.leave = lv;
            this.name = empRepo.GetName(leave.EmpID);
        }
    }


}
