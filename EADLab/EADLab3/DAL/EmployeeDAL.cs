using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EADLab3.Models;

namespace EADLab3.DAL
{
    public class EmployeeDAL
    {
        private static Dictionary<string, Employee> allEmployee = new Dictionary<string, Employee>();

        public static List<Employee> SelectAll()
        {
            return allEmployee.Values.ToList();
        }

        public static Employee Select(string nric)
        {
            Employee emp = null;
            if (allEmployee.ContainsKey(nric))
            {
                emp = allEmployee[nric];
            }
            return emp;
        }

        public static void Insert(Employee emp)
        {
            allEmployee.Add(emp.NRIC, emp);
        }
    }
}