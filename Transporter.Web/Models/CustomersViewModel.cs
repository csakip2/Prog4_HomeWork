using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transporter.Web.Models
{
    public class CustomersViewModel
    {
        public Customer EditedCustomer { get; set; }
        public List<Customer> ListOfCustomers { get; set; }
    }
}