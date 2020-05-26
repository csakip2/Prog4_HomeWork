using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transporter.Logic;
using Transporter.Web.Models;

namespace Transporter.Web.Controllers
{
    public class CustomerController : Controller
    {
        ILogic logic;
        IMapper mapper;
        CustomersViewModel vm;

        public CustomerController()
        {
            logic = new Logic.Logic();
            mapper = MapperFactory.CreateMapper();
            vm = new CustomersViewModel();
            vm.EditedCustomer = new Customer();
            var customers = logic.GetCustomerList();
            vm.ListOfCustomers = mapper.Map<IList<Data.CUSTOMER>, List<Models.Customer>>(customers);
        }

        private Customer GetCustonerModel(int id)
        {
            Data.CUSTOMER oneCustomer = logic.GetOneCustomer(id);
            return mapper.Map<Data.CUSTOMER, Models.Customer>(oneCustomer);
        }

        // GET: Customer
        public ActionResult Index()
        {
            ViewData["editAction"] = "AddNew";
            return View("CustomerIndex", vm);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View("CustomerDetails", GetCustonerModel(id));
        }

        // GET: Customer/Remove/5
        public ActionResult Remove(int id)
        {
            TempData["editResult"] = "Delete Failed";
            if (logic.RemoveCustomer(id))
            {
                TempData["editResult"] = "Delete OK";
            }
            return RedirectToAction("Index");
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["editAction"] = "Edit";
            vm.EditedCustomer = GetCustonerModel(id);
            return View("CustomerIndex", vm);
        }

        //POST: Customer/Edit
        [HttpPost]
        public ActionResult Edit(Customer customer, string editAction)
        {
            if (ModelState.IsValid && customer != null)
            {
                TempData["editResult"] = "Edit OK";
                if (editAction == "AddNew")
                {
                    logic.AddCustomer(customer.Name, customer.Adress, customer.PhoneNum, customer.EMail);
                }
                else
                {
                    logic.ChangeCustomer(customer.Id, customer.Name, customer.Adress, customer.PhoneNum, customer.EMail);
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["editAction"] = "Edit";
                vm.EditedCustomer = customer;
                return View("CustomerIndex", vm);
            }
        }
    }
}
