using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstCoreAppUsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreAppUsingMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository = null;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            //CustomerRepository customerRepository = new CustomerRepository();
            ViewBag.MyName = "atharva";
            ViewData["MyName"] = "atharva";
            TempData["MyName"] = "atharva";
            var result = _repository.GetAllCustomers();
            return View(result);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            //CustomerRepository customerRepository = new CustomerRepository();
            var result = _repository.GetCustomerById(id);
            return View(result);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            //CustomerRepository customerRepository = new CustomerRepository();
            var result = _repository.CreateCustomer(customer);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _repository.GetCustomerById(id);
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            var result = _repository.UpdateCustomer(customer);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _repository.GetCustomerById(id);
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Customer customer)
        {
            var result = _repository.DeleteCustomer(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
