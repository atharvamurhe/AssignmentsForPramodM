using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstCoreAppUsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreAppUsingMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Customer> customers = new List<Customer>();
        private readonly ICustomerRepository _repository = null;

        public HomeController(ILogger<HomeController> logger, ICustomerRepository repository)
        {
            customers.Add(new Customer { ID = 001, Name = "Atharva", Address = "Talegaon Dabhade", Phone = "9405402638", TotalBill = 5000.00M });
            customers.Add(new Customer { ID = 002, Name = "Tanmay", Address = "Pune", Phone = "8087548493", TotalBill = 1500.50M });
            customers.Add(new Customer { ID = 003, Name = "Vinayak", Address = "Undri", Phone = "8975615130", TotalBill = 5200.00M });
            customers.Add(new Customer { ID = 004, Name = "Veena", Address = "Pune", Phone = "7775079541", TotalBill = 3000.80M });
            customers.Add(new Customer { ID = 005, Name = "Prajakta", Address = "Pune", Phone = "9293574985", TotalBill = 2300.00M });
            customers.Add(new Customer { ID = 006, Name = "Sumeet", Address = "Talegaon Dabhade", Phone = "8934572346", TotalBill = 500.15M });
            customers.Add(new Customer { ID = 007, Name = "Omkar", Address = "Talegaon Dabhade", Phone = "7263492594", TotalBill = 9000.60M });
            customers.Add(new Customer { ID = 008, Name = "Aditya", Address = "Bangalore", Phone = "9823576734", TotalBill = 8700.20M });
            customers.Add(new Customer { ID = 009, Name = "Amit", Address = "Pune", Phone = "9287357235", TotalBill = 3400.00M });
            customers.Add(new Customer { ID = 010, Name = "Yash", Address = "Talegaon Dabhade", Phone = "89234674347", TotalBill = 7000.00M });
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            List<Customer> custList = _repository.GetAllCustomers();
            ViewBag.CustList = custList;
            ViewData["CustList"] = custList;

            return View(custList);
        }

        public IActionResult Customers()
        {
            return View(customers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
