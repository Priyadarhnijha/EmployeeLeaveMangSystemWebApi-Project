using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeLeaveMang.ServiceLayer;
using EmployeeLeaveMang.DomainLayer.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeLeaveMangSystemWebApi_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly InterfaceEmployeeService EmployeeService;
        private readonly ILogger<EmployeeController> _logger;

        //public EmployeeController(InterfaceEmployeeService employeeService, ILogger<EmployeeController> logger) 
        //{
        //    _logger = logger;
        //    _logger.LogInformation("Employee called");
        //    EmployeeService = employeeService;  

        //}
        #region "Constructor init"
        public EmployeeController(InterfaceEmployeeService EmployeeService)
        {
            this.EmployeeService = EmployeeService;
        }
        #endregion

        #region "Api Core Functionality"
        //[HttpGet(nameof(GetAllEmployeeClasses))]
        //public ActionResult GetAllEmployeeClasses()
        //{
        //    var Employees = EmployeeService.GetAllEmployeeClasses();
        //    if (Employees != null && Employees.Count > 1)
        //    {
        //        return Ok(Employees);
        //    }
        //    return BadRequest("Not found");
        //}
        #endregion

        #region "Search Employee Leave Taken"
        [HttpGet(nameof(GetEmployeeById))]
        public ActionResult GetEmployeeById(int EmpId)
        {
            var EmployeeClass = EmployeeService.GetEmployeeById(EmpId);
            if (EmployeeClass != null)
            {
                return Ok(EmployeeClass);
            }
            return BadRequest("Not found");
        }
        #endregion
        #region "Add Employee"
        [HttpPost(nameof(AddEmployee))]
        public ActionResult AddEmployee(EmployeeClass EmployeeClass)
        {
            EmployeeService.InsertEmployee(EmployeeClass);

            return Ok("Employee added");
        }
        #endregion
        #region "Update Employee Data"
        [HttpPut(nameof(UpdateEmployee))]
        public ActionResult UpdateEmployee(EmployeeClass employee)
        {
            EmployeeService.UpdateEmployee(employee);

            return Ok("Employee Updated");
        }
        #endregion
        #region "Search Employee List"
        [HttpGet(nameof(GetAllEmployee))]
        public ActionResult GetAllEmployee()
        {
            var EmployeeClass = EmployeeService.GetAllEmployee();
            if (EmployeeClass != null)
            {
                return Ok(EmployeeClass);
            }
            return BadRequest("Not found");
        }
        #endregion
        #region "Leave Type"
        [HttpGet(nameof(GetAllLeaveType))]
        public ActionResult GetAllLeaveType()
        {
            var LeaveDetail = EmployeeService.GetAllLeaveType();
            if (LeaveDetail != null)
            {
                return Ok(LeaveDetail);
            }
            return BadRequest("Not found");
        }
        #endregion
        #region "Apply Planned Leaves"
        [HttpPost(nameof(ApplyPLeave))]
        public ActionResult ApplyPLeave(ApplyPlannedLeave applyPlannedLeave)
        {
            EmployeeService.ApplyPL(applyPlannedLeave);

            return Ok("Leave Applied Successfully");
        }
        #endregion
        
        #region "Cancel Planned Leaves"
        [HttpPut(nameof(CancelPlannedLeave))]
        public ActionResult CancelPlannedLeave(int EmpId)
        {
            EmployeeService.DeletePLeave(EmpId);

            return Ok("Leave Cancelled");
        }
        #endregion
    }
}
