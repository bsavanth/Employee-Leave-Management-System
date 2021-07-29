using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagement.Models;
using LeaveManagement.ViewModels;

namespace LeaveManagement.Controllers
{
    public class LeaveController : Controller
    {

        IEmployeeRepository employeeRepo;
        ILeaveRepository leaveRepo;


        public LeaveController(IEmployeeRepository emprepo, ILeaveRepository levrepo)
        {

            this.employeeRepo = emprepo;
            this.leaveRepo = levrepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddLeave()
        {


            EmployeeViewModel empViewModel = new EmployeeViewModel
            {

                employees = employeeRepo.GetEmployees()
                
            };

            return View(empViewModel);
        }

       [HttpPost]
        public IActionResult AddLeave(EmployeeViewModel employeeViewModel)
        {

            employeeViewModel.leave.NoOfDays = Convert.ToInt32(employeeViewModel.leave.ToDate.Subtract(employeeViewModel.leave.FromDate).TotalDays);
            employeeViewModel.leave.Status = "Pending";
            employeeViewModel.employees = employeeRepo.GetEmployees();
            leaveRepo.AddLeave(employeeViewModel.leave);

            return RedirectToAction("Index");

        }

        public IActionResult ModifyLeaveStatus()
        {
            List<Leave> pending = leaveRepo.GetPendingLeaves();

            List<EmployeeNameView> nameView = new List<EmployeeNameView>();

            foreach (Leave lv in pending)
            {
                nameView.Add(new EmployeeNameView(lv, employeeRepo));
            }

            return View(nameView);

        }

        public IActionResult Edit(int Id)
        {
            Leave lv = leaveRepo.GetLeave(Id);
            return View(lv);
        }

        [HttpPost]
        public IActionResult Edit(Leave lv)
        {

            lv.NoOfDays = Convert.ToInt32((lv.ToDate.Subtract(lv.FromDate)).TotalDays);
            leaveRepo.UpdateLeave(lv);
            return RedirectToAction("ModifyLeaveStatus");
        }

    }


   

}
