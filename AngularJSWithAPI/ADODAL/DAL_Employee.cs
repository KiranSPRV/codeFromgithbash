using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJSWithAPI.Models;

namespace AngularJSWithAPI.ADODAL
{
    public class DAL_Employee
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> lstEmp = new List<Employee>();
            try
            {
                lstEmp.Add(new Employee() { EmployeeID = 1, EmpName = "EMP", EmpAge = 16, EmpCity = "Hyd" });
            }
            catch (Exception ex)
            {
            }
            return lstEmp;
        }
    }
}