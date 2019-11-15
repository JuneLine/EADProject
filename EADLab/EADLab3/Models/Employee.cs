using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADLab3.Models
{
    public class Employee
    {
        // Define class properties
        public string NRIC { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Dept { get; set; }
        public double MthlyWage { get; set; }

        // Not stored in DB
        public double EmployeeCPF { get; set; }
        public double EmployerCPF { get; set; }
    }
}