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

        public EmployeeService(ApplicationEmployeeContext ApplicationEmployeeContext)
        {
            ApplicationEmployeeContext = ApplicationEmployeeContext;
        }

        //public EmployeeService(ApplicationEmployeeContext ApplicationEmployeeContext)
        //{
        //    ApplicationEmployeeContext = ApplicationEmployeeContext;
        //}
       public  IList<EmployeeClass>GetAllEmployeeClasses(string EmpName)
        {
          return ApplicationEmployeeContext.Set<EmployeeClass>().ToList();
        }

        IList<EmployeeClass> InterfaceEmployeeService.GetAllEmployeeClass()
        {
            throw new NotImplementedException();
        }

        public EmployeeClass GetEmployeeClasses(string EmpName)
        {
            return ApplicationEmployeeContext.Find<EmployeeClass>(EmpName);
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

        object InterfaceEmployeeService.GetAllEmployeeClasses()
        {
            throw new NotImplementedException();
        }
    }
}
