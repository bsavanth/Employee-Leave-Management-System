using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace LeaveManagement.Models
{
    public class LeaveContext:DbContext
    {

        public LeaveContext(DbContextOptions<LeaveContext> db): base(db)
        {

        }

        public DbSet<Leave> Leave { get; set; }

    }
}
