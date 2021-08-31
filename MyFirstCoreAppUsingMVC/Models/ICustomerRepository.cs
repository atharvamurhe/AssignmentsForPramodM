using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreAppUsingMVC.Models
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerById(int Id);
        public bool CreateCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(int id);
    }
}
