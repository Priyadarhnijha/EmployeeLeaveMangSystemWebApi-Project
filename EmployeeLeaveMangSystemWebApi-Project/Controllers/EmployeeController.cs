using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeLeaveMang.ServiceLayer;
using EmployeeLeaveMang.DomainLayer.Models;


namespace EmployeeLeaveMangSystemWebApi_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly InterfaceEmployeeService EmployeeService;
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
        [HttpPost(nameof(AddEmployee))]
        public ActionResult AddEmployee(EmployeeClass EmployeeClass)
        {
            EmployeeService.InsertEmployee(EmployeeClass);

            return Ok("Employee added");
        }
        [HttpPut(nameof(UpdateEmployee))]
        public ActionResult UpdateEmployee(EmployeeClass customer)
        {
            EmployeeService.UpdateEmployee(customer);

            return Ok("Employee Updated");
        }
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

        //[HttpPut(nameof(DeleteCustomer))]
        //public ActionResult DeleteCustomer(string customername)
        //{
        //    EmployeeService.DeleteCustomer(customername);

        //    return Ok("Customer Deleted");
        //}

    }
}
