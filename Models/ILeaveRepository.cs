using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public interface ILeaveRepository
    {

        public int AddLeave(Leave leave);

        public List<Leave> GetLeaves();

        public List<Leave> GetPendingLeaves();

        public Leave GetLeave(int Id);

        public int UpdateLeave(Leave lv);

    }
}
