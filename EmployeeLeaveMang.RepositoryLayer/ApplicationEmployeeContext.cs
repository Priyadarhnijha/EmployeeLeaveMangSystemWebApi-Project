using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeLeaveMang.DomainLayer.Models;

namespace EmployeeLeaveMang.RepositoryLayer
{
    public class ApplicationEmployeeContext : DbContext

    {
        public ApplicationEmployeeContext(DbContextOptions options) : base(options)
        {
        
        }
        DbSet<EmployeeClass> EmployeeClassDetail { get; set; }
        DbSet<LeaveDetail> LeaveDetails { get; set; }

        DbSet<ApplyPlannedLeave> ApplyPlannedLeaves { get; set; }
    }
}
