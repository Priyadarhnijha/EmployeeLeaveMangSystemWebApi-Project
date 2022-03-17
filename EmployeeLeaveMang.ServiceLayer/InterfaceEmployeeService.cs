﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLeaveMang.RepositoryLayer;
using EmployeeLeaveMang.DomainLayer.Models;



namespace EmployeeLeaveMang.ServiceLayer
{
     public  interface InterfaceEmployeeService
    {
       IList<EmployeeClass> GetAllEmployee();



        EmployeeClass GetEmployeeById(int EmpId);

        void InsertEmployee(EmployeeClass employee);
        void UpdateEmployee(EmployeeClass employee);






        //object GetAllEmployeeClasses();
      //  IList<EmployeeClass> GetAllEmployeeClass();
       // object GetAllEmployeeClasses();

        //void DeleteEmployee(String EmpName);


    }
}
