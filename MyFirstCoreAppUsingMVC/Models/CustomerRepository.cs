using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreAppUsingMVC.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> customers = new List<Customer>()
        {
            new Customer { ID = 1, Name = "Atharva", Address = "Talegaon Dabhade", Phone = "9405402638", TotalBill = 5000.00M },
            new Customer { ID = 2, Name = "Tanmay", Address = "Pune", Phone = "8087548493", TotalBill = 1500.50M },
            new Customer { ID = 3, Name = "Vinayak", Address = "Undri", Phone = "8975615130", TotalBill = 5200.00M },
            new Customer { ID = 4, Name = "Veena", Address = "Pune", Phone = "7775079541", TotalBill = 3000.80M },
            new Customer { ID = 5, Name = "Prajakta", Address = "Pune", Phone = "9293574985", TotalBill = 2300.00M },
            new Customer { ID = 6, Name = "Sumeet", Address = "Talegaon Dabhade", Phone = "8934572346", TotalBill = 500.15M },
            new Customer { ID = 7, Name = "Omkar", Address = "Talegaon Dabhade", Phone = "7263492594", TotalBill = 9000.60M },
            new Customer { ID = 8, Name = "Aditya", Address = "Bangalore", Phone = "9823576734", TotalBill = 8700.20M },
            new Customer { ID = 9, Name = "Amit", Address = "Pune", Phone = "9287357235", TotalBill = 3400.00M },
            new Customer { ID = 10, Name = "Yash", Address = "Talegaon Dabhade", Phone = "89234674347", TotalBill = 7000.00M }
        };

        //public CustomerRepository()
        //{
        //    customers = new List<Customer>();
        //    customers.Add(new Customer { ID = 1, Name = "Atharva", Address = "Talegaon Dabhade", Phone = "9405402638", TotalBill = 5000.00M });
        //    customers.Add(new Customer { ID = 2, Name = "Tanmay", Address = "Pune", Phone = "8087548493", TotalBill = 1500.50M });
        //    customers.Add(new Customer { ID = 3, Name = "Vinayak", Address = "Undri", Phone = "8975615130", TotalBill = 5200.00M });
        //    customers.Add(new Customer { ID = 4, Name = "Veena", Address = "Pune", Phone = "7775079541", TotalBill = 3000.80M });
        //    customers.Add(new Customer { ID = 5, Name = "Prajakta", Address = "Pune", Phone = "9293574985", TotalBill = 2300.00M });
        //    customers.Add(new Customer { ID = 6, Name = "Sumeet", Address = "Talegaon Dabhade", Phone = "8934572346", TotalBill = 500.15M });
        //    customers.Add(new Customer { ID = 7, Name = "Omkar", Address = "Talegaon Dabhade", Phone = "7263492594", TotalBill = 9000.60M });
        //    customers.Add(new Customer { ID = 8, Name = "Aditya", Address = "Bangalore", Phone = "9823576734", TotalBill = 8700.20M });
        //    customers.Add(new Customer { ID = 9, Name = "Amit", Address = "Pune", Phone = "9287357235", TotalBill = 3400.00M });
        //    customers.Add(new Customer { ID = 10, Name = "Yash", Address = "Talegaon Dabhade", Phone = "89234674347", TotalBill = 7000.00M });
        //}

        public List<Customer> GetAllCustomers()
        {
            return customers;
        }

        public Customer GetCustomerById(int Id)
        {
            var customer = customers.FirstOrDefault(item => item.ID == Id); //Returns the first element with matching value in a collection or a default value.
            //var customer = customers.First(item => item.ID == Id) //Returns the first element with matching value in a collection.
            //var customer = customers.DefaultIfEmpty(); //Returns all elements in a collection or Default if empty.
            //var customer = customers.LastOrDefault(); //Returns the last element of a collection or a default value if empty.
            return customer;
        }

        public bool CreateCustomer(Customer customer)
        {
            try
            {
                customer.ID = customers.Select(item => item.ID).Max() + 1;
                customers.Add(customer);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
