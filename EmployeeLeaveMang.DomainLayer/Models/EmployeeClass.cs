using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveMang.DomainLayer.Models
{

    public class EmployeeClass
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        public char EmpGender { get; set; }


    }
}
