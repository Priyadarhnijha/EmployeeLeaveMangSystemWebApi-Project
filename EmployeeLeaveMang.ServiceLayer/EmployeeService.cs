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

        #region "Constructor Employee Service Class"
        public EmployeeService(ApplicationEmployeeContext applicationEmployeeContext)
        {
            this.ApplicationEmployeeContext = applicationEmployeeContext;
        }
        #endregion

        //public EmployeeService(ApplicationEmployeeContext ApplicationEmployeeContext)
        //{
        //    ApplicationEmployeeContext = ApplicationEmployeeContext;
        //}
        #region "Method for employee list"
        public IList<EmployeeClass>GetAllEmployee()
        {
          return ApplicationEmployeeContext.Set<EmployeeClass>().ToList();
        }
        #endregion

        #region "Method for Leave Type "
        public IList<LeaveDetail>GetAllLeaveType()
        {
            return ApplicationEmployeeContext.Set<LeaveDetail>().ToList();
        }
        #endregion

        #region "Method to search Employee Leave Taken"
        public EmployeeClass GetEmployeeById(int EmpId)
        {
            return ApplicationEmployeeContext.Find<EmployeeClass>(EmpId);
        }
        #endregion

        #region "method for Add employee"
        public void InsertEmployee(EmployeeClass employee)
        {
            ApplicationEmployeeContext.Add<EmployeeClass>(employee);
            ApplicationEmployeeContext.SaveChanges();

        }
        #endregion

        #region "Method for Update Employee data"
        void InterfaceEmployeeService.UpdateEmployee(EmployeeClass employee)
        {
            ApplicationEmployeeContext.Update<EmployeeClass>(employee);
            ApplicationEmployeeContext.SaveChanges();

        }
        #endregion

        #region " Method for Applying Planned leave"
        public void ApplyPL(ApplyPlannedLeave applyPlannedLeave)
        {
            ApplicationEmployeeContext.Add<ApplyPlannedLeave>(applyPlannedLeave);
            ApplicationEmployeeContext.SaveChanges();

        }
        #endregion

        #region  "Method to cancel planned leaves"
        public void DeletePLeave(int EmpId)
        {
            ApplyPlannedLeave applyPlannedLeave = GetLeave(EmpId);
            if (applyPlannedLeave != null)
            {
                ApplicationEmployeeContext.Remove<ApplyPlannedLeave>(applyPlannedLeave);
                ApplicationEmployeeContext.SaveChanges();
            }
            
        }
        
        private ApplyPlannedLeave GetLeave(int EmpId)
        {
            return ApplicationEmployeeContext.Find<ApplyPlannedLeave>(EmpId);

            
        }
        #endregion
    }
}
