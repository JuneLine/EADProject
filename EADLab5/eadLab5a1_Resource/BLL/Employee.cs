
using eadLab5.DAL2;
using System;
using System.Collections.Generic;

namespace eadLab5.BLL
{
    public class Employee
    {
        // Define class properties
        public string NRIC { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Dept { get; set; }
        public double MthlyWage { get; set; }
        public double EmployeeCPF { get; set; }
        public double EmployerCPF { get; set; }

        // Default constructor
        public Employee()
        {

        }
        // Define a constructor to initialize all the properties
        public Employee(string nric, string name, DateTime dob, string dept, double mthlyWage)
        {
            NRIC = nric;
            Name = name;
            Birthdate = dob;
            Dept = dept;
            MthlyWage = mthlyWage;
            EmployeeCPF = ComputeEeCPF();
            EmployerCPF = ComputeErCPF();
        }

        public int ComputeAge()
        {
            DateTime now = DateTime.Today;
            int age = DateTime.Today.Year - Birthdate.Year;
            if (now.Month < Birthdate.Month)
            {
                age--;
            }
            else
            {
                if (now.Month == Birthdate.Month && now.Day < Birthdate.Day)
                {
                    age--;
                }
            }
            return age;
        }

        public double ComputeEeCPF()
        {
            double contribute = 0;
            double payCap = MthlyWage;
            if (MthlyWage > 6000)
                payCap = 6000;

            int age = ComputeAge();
            if (age <= 55)
            {
                contribute = payCap * 0.2;
            }
            else if (age <= 60)
            {
                contribute = payCap * 0.13;
            }
            else if (age <= 65)
            {
                contribute = payCap * 0.075;
            }
            else
                contribute = payCap * 0.05;
            return Math.Round(contribute, 2);
        }

        public double ComputeErCPF()
        {
            double contribute = 0;
            double payCap = MthlyWage;
            if (MthlyWage > 6000)
            {
                payCap = 6000;
            }

            int age = ComputeAge();
            if (age <= 55)
            {
                contribute = payCap * 0.17;
            }
            else if (age <= 60)
            {
                contribute = payCap * 0.13;
            }
            else if (age <= 65)
            {
                contribute = payCap * 0.09;
            }
            else
                contribute = payCap * 0.075;
            return Math.Round(contribute, 2);
        }

        public int AddEmployee()
        {
            EmployeeDAO dao = new EmployeeDAO();
            int result = dao.Insert(this);
            return result;
        }
        public List<Employee> GetAllEmployee()
        {
            EmployeeDAO dao = new EmployeeDAO();
            return dao.SelectAll();
        }

        public Employee GetEmployeeById(string nric)
        {
            EmployeeDAO dao = new EmployeeDAO();
            return dao.SelectById(nric);
        }

    }
}