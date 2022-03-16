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
            EmployeeService = EmployeeService;
        }
        #endregion

        #region "Api Core Functionality"
        [HttpGet(nameof(GetAllEmployeeClasses))]
        public ActionResult GetAllEmployeeClasses()
        {
            var EmployeeClass = EmployeeService.GetAllEmployeeClasses();
            if (EmployeeClass != null && EmployeeClass.Count > 0)
            {
                return Ok(EmployeeClass);
            }
            return BadRequest("Not found");
        }
        #endregion
        [HttpGet(nameof(GetEmployeeClasses))]
        public ActionResult GetEmployeeClasses(string name)
        {
            var EmployeeClass = EmployeeService.GetEmployeeClasses(name);
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

        //[HttpPut(nameof(DeleteCustomer))]
        //public ActionResult DeleteCustomer(string customername)
        //{
        //    EmployeeService.DeleteCustomer(customername);

        //    return Ok("Customer Deleted");
        //}

    }
}
