using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Models
{
    public class Employee
    {


        //Annotations for ID field
        [Display(Name = "Employee ID")]
        [Key]

        // ID field
        public int ID { get; set; }





        //Annotations for Name field
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Name is a required Field")]
        [MaxLength(40)]

        //Name field
        public string Name { get; set; }




        //Annotations for Name field
        [RegularExpression(@"^M(anager)?$|^A(ssociate)?$|^I^T(department)?$", ErrorMessage = "Designation is not valid.")]
        [Display(Name = "Employee Designation")]
        [Required(ErrorMessage = "Designation is a required Field")]
        [MaxLength(30)]


        //Name field
        public string Designation { get; set; }


    }
}
