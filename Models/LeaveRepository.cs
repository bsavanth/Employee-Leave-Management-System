using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Models
{
    public class LeaveRepository : ILeaveRepository
    {

        LeaveContext _context;


        public LeaveRepository(LeaveContext context)
        {
            this._context = context;
        }

        public int AddLeave(Leave leave)
        {
            _context.Add(leave);
            _context.SaveChanges();
            return leave.LeaveID;
        }

        public List<Leave> GetLeaves()
        {
            return _context.Leave.ToList();
        }

        public List<Leave> GetPendingLeaves()
        {
            return _context.Leave.Where(leave => leave.Status =="Pending").ToList();

        }

        public Leave GetLeave(int Id)
        {
            Leave lv = _context.Leave.Where(leave => leave.LeaveID == Id).FirstOrDefault();
            return lv;
        }

        public int UpdateLeave(Leave lv)
        {
            
             _context.Entry(lv).State = EntityState.Modified;
            _context.SaveChanges();

            return 1;
        }

    }



}
