using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveMang.DomainLayer.Models
{
    public class LeaveDetail
    {
        public int LeaveDuration { get; set; }

        [Key]
        public int LeaveId { get; set; }

        public string LeaveType { get; set; }
    }
}
