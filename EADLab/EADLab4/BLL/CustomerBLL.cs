using EADLab4.DAL;
using EADLab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADLab4.BLL
{
    public class CustomerBLL
    {
        public static Customer GetCustomer(string id)
        {
            return CustomerDAL.Select(id);
        }
    }
}