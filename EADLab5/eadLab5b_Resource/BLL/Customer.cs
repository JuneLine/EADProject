using eadLab5a23.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5a23.BLL
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string Mobile { get; set; }
        public Customer()
        {

        }
        public Customer(string id, string name, string address, string home, string hp)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.HomePhone = home;
            this.Mobile = hp;
        }
        public Customer GetCustomerById(string custId)
        {
            CustomerDAO dao = new CustomerDAO();
            return dao.SelectById(custId);
        }
    }
}