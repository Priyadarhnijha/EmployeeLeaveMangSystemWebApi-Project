using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeLeaveMang.ServiceLayer;
using EmployeeLeaveMang.DomainLayer.Models;
using Microsoft.Extensions.Logging;
using System;

namespace EmployeeLeaveMangSystemWebApi_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly InterfaceEmployeeService EmployeeService;
        private readonly ILogger<EmployeeController> _logger;

        
        #region "Constructor init"
        public EmployeeController(InterfaceEmployeeService EmployeeService, ILogger<EmployeeController> logger)
        {
            _logger = logger;
            _logger.LogInformation("Employee Added");
            this.EmployeeService = EmployeeService;
        }
        #endregion

        

        #region "Search Employee Leave Taken"
        [HttpGet(nameof(GetEmployeeById))]
        public ActionResult GetEmployeeById(int EmpId)
        {
            try 
            {
                var EmployeeClass = EmployeeService.GetEmployeeById(EmpId);
                if (EmployeeClass != null)
                {
                    return Ok(EmployeeClass);
                }
            }
            catch(Exception e) 
            {
                _logger.LogError("Exception Occured",e.InnerException);
            }
            
            return BadRequest("Not found");
        }
        #endregion

        #region "Add Employee"
        [HttpPost(nameof(AddEmployee))]
        public ActionResult AddEmployee(EmployeeClass EmployeeClass)
        {
            try 
            {
                EmployeeService.InsertEmployee(EmployeeClass);

                return Ok("Employee added");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        #endregion

        #region "Update Employee Data"
        [HttpPut(nameof(UpdateEmployee))]
        public ActionResult UpdateEmployee(EmployeeClass employee)
        {
            try 
            {
                EmployeeService.UpdateEmployee(employee);

                return Ok("Employee Updated");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        #endregion

        #region "Search Employee List"
        [HttpGet(nameof(GetAllEmployee))]
        public ActionResult GetAllEmployee()
        {
            try 
            {
                var EmployeeClass = EmployeeService.GetAllEmployee();
                if (EmployeeClass != null)
                {
                    return Ok(EmployeeClass);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }

            return BadRequest("Not found");
        }

        #endregion

        #region "Leave Type"
        [HttpGet(nameof(GetAllLeaveType))]
        public ActionResult GetAllLeaveType()
        {
            try 
            {
                var LeaveDetail = EmployeeService.GetAllLeaveType();
                if (LeaveDetail != null)
                {
                    return Ok(LeaveDetail);
                }
            }
            
             catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");
        }
        #endregion
        #region "Apply Planned Leaves"
        [HttpPost(nameof(ApplyPLeave))]
        public ActionResult ApplyPLeave(ApplyPlannedLeave applyPlannedLeave)
        {
            try 
            {
                EmployeeService.ApplyPL(applyPlannedLeave);

                return Ok("Leave Applied Successully");
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");

        }
        #endregion
        
        #region "Cancel Planned Leaves"
        [HttpPut(nameof(CancelPlannedLeave))]
        public ActionResult CancelPlannedLeave(int EmpId)
        {
            try 
            {
                EmployeeService.DeletePLeave(EmpId);

                return Ok("Leave Cancelled");

            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occured", e.InnerException);
            }
            return BadRequest("Not found");
        }
        #endregion
    }
}
