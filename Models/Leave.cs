using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace LeaveManagement.Models
{
    public class Leave
    {


        // Annotations for  Leave ID field
        [Display(Name = "Leave ID")]
        [Key]

        // Leave ID field
        public int LeaveID { get; set; }






        // Annotations for Employee ID field
        [Display(Name = "Employee ID")]
        [Required(ErrorMessage = "Employee ID is a required Field")]

        // Employee ID field
        public int EmpID { get; set; }







        // Annotations Number of Days
        [Display(Name = "Number of Days")]
        [Range(1, 365, ErrorMessage = "Please enter correct value")]

        // Number of Days field
        public int NoOfDays { get; set; }







        // Annotations for From Date
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is a required Field")]

        // From Date field
        public DateTime FromDate { get; set; }







        // Annotations for To Date
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is a required Field")]
        [DateGreaterThan("FromDate")]
        // To Date field
        public DateTime ToDate { get; set; }












        // Annotatios for Status
        [DefaultValue("Pending")]
        [Display(Name = "Status")]
        [RegularExpression(@"^P(ending)?$|^A(ccepted)?$|^R(ejected)?$", ErrorMessage = "Status is not valid.")]

        // Status field
        public string Status { get; set; }


        // Annotations for Remarks
        [Display(Name = "Remarks")]
        [StringLength(500)]

        public string Remarks { get; set; }



    }


    // Custom Validation for start date and end date of the leave
    [AttributeUsage(AttributeTargets.Property)]
    public class DateGreaterThanAttribute : ValidationAttribute
    {

        private string DateToCompareFieldName { get; set; }

        public DateGreaterThanAttribute(string dateToCompareFieldName)
        {
            DateToCompareFieldName = dateToCompareFieldName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime laterDate = (DateTime)value;

            DateTime earlierDate = (DateTime)validationContext.ObjectType.GetProperty(DateToCompareFieldName).GetValue(validationContext.ObjectInstance, null);

            if (laterDate > earlierDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(string.Format("{0} precisa ser menor!", DateToCompareFieldName));
            }
        }
    }
}
