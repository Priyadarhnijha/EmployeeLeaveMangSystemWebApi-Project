using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveMang.DomainLayer.Models
{
    public class ApplyPlannedLeave
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        public int LeaveDuration { get; set; }

        public string LeaveReason { get; set; }

    }
}
