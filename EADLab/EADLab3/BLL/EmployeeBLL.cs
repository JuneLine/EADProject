using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EADLab3.Models;
using EADLab3.DAL2;

namespace EADLab3.BLL
{
    public class EmployeeBLL
    {
        public static List<Employee> GetAll()
        {
            List<Employee> empList = EmployeeDAL.SelectAll().OrderBy(e => e.Name).ToList();
            foreach(Employee emp in empList)
            {
                ComputeCPF(emp);
            }
            return empList;
        }

        public static bool ValidateNRICNotDuplicate(string nric)
        {
            Employee emp = EmployeeDAL.Select(nric);
            return emp == null;
        }

        public static bool ValidateBirthDate(DateTime birthDate)
        {
            int minAge = 17;
            int age = GetAge(birthDate);
            return age >= minAge;
        }

        public static void AddEmployee(string nric, string name, DateTime birthDate, string dept, double mthlyWage)
        {
            Employee emp = new Employee();
            emp.NRIC = nric;
            emp.Name = name;
            emp.BirthDate = birthDate;
            emp.Dept = dept;
            emp.MthlyWage = mthlyWage;

            EmployeeDAL.Insert(emp);
        }

        private static int GetAge(DateTime birthDate)
        {
            DateTime now = DateTime.Today;
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate.AddYears(age) > now)
            {
                age--;
            }
            return age;
        }

        private static void ComputeCPF(Employee emp)
        {
            double employeeCPF = 0;
            double employerCPF = 0;

            double payCap = 6000;
            double mthlyWageCal = emp.MthlyWage > payCap ? payCap : emp.MthlyWage;

            int age = GetAge(emp.BirthDate);
            if (age <= 55)
            {
                employeeCPF = mthlyWageCal * 0.2;
                employerCPF = mthlyWageCal * 0.17;
            }
            else if (age <= 60)
            {
                employeeCPF = mthlyWageCal * 0.13;
                employerCPF = mthlyWageCal * 0.13;
            }
            else if (age <= 65)
            {
                employeeCPF = mthlyWageCal * 0.075;
                employerCPF = mthlyWageCal * 0.09;
            }
            else
            {
                employeeCPF = mthlyWageCal * 0.05;
                employerCPF = mthlyWageCal * 0.075;
            }

            emp.EmployeeCPF = Math.Round(employeeCPF, 2);
            emp.EmployerCPF = Math.Round(employerCPF, 2);
        }
    }
}