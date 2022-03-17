using EmployeeLeaveMang.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLeaveMang.RepositoryLayer;


namespace EmployeeLeaveMang.ServiceLayer
{
    public class EmployeeService : InterfaceEmployeeService
    {
        public ApplicationEmployeeContext ApplicationEmployeeContext;

        public EmployeeService(ApplicationEmployeeContext applicationEmployeeContext)
        {
            this.ApplicationEmployeeContext = applicationEmployeeContext;
        }

        //public EmployeeService(ApplicationEmployeeContext ApplicationEmployeeContext)
        //{
        //    ApplicationEmployeeContext = ApplicationEmployeeContext;
        //}
       public  IList<EmployeeClass>GetAllEmployee()
        {
          return ApplicationEmployeeContext.Set<EmployeeClass>().ToList();
        }

        public IList<LeaveDetail>GetAllLeaveType()
        {
            return ApplicationEmployeeContext.Set<LeaveDetail>().ToList();
        }
        //IList<EmployeeClass> InterfaceEmployeeService.GetAllEmployeeClass()
        //{
        //    throw new NotImplementedException();
        //}

        public EmployeeClass GetEmployeeById(int EmpId)
        {
            return ApplicationEmployeeContext.Find<EmployeeClass>(EmpId);
        }

       public  void InsertEmployee(EmployeeClass employee)
        {
            ApplicationEmployeeContext.Add<EmployeeClass>(employee);
            ApplicationEmployeeContext.SaveChanges();

        }

        void InterfaceEmployeeService.UpdateEmployee(EmployeeClass employee)
        {
            ApplicationEmployeeContext.Update<EmployeeClass>(employee);
            ApplicationEmployeeContext.SaveChanges();

        }

        // void  InterfaceEmployeeService.GetAllEmployeeClasses()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
