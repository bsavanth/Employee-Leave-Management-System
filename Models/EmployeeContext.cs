using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace LeaveManagement.Models
{
    public class EmployeeContext:DbContext
    {


        public EmployeeContext(DbContextOptions<EmployeeContext> db) : base(db)
        {

        }

        public DbSet<Employee> Employee { get; set; }

    }
}
