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
        public void ApplyPL(ApplyPlannedLeave applyPlannedLeave)
        {
            ApplicationEmployeeContext.Add<ApplyPlannedLeave>(applyPlannedLeave);
            ApplicationEmployeeContext.SaveChanges();

        }
        public void DeletePLeave(int EmpId)
        {
            ApplyPlannedLeave applyPlannedLeave = GetLeave(EmpId);
            if (applyPlannedLeave != null)
            {
                ApplicationEmployeeContext.Remove<ApplyPlannedLeave>(applyPlannedLeave);
                ApplicationEmployeeContext.SaveChanges();
            }
            //throw new NotImplementedException();
        }

        private ApplyPlannedLeave GetLeave(int EmpId)
        {
            return ApplicationEmployeeContext.Find<ApplyPlannedLeave>(EmpId);

            //throw new NotImplementedException();
        }
        // void  InterfaceEmployeeService.GetAllEmployeeClasses()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
