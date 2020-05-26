using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Transporter.Logic;
using Transporter.Web.Models;

namespace Transporter.Web.Controllers
{
    public class CustomerApiController : ApiController
    {
        public class ApiResult
        {
            public bool OperationResult { get; set; }
        }

        ILogic logic;
        IMapper mapper;
        public CustomerApiController()
        {
            logic = new Logic.Logic();
            mapper = MapperFactory.CreateMapper();
        }

        // GET: api/CustomerApi/all
        [ActionName("all")]
        [HttpGet]
        public IEnumerable<Models.Customer> GetAll()
        {
            var customers = logic.GetCustomerList();
            return mapper.Map<IList<Data.CUSTOMER>, List<Models.Customer>>(customers);
        }

        // GET: api/CustomerApi/del/5
        [ActionName("del")]
        [HttpGet]
        public ApiResult DelOneCustomer(int id)
        {
            bool res = logic.RemoveCustomer(id);
            return new ApiResult() { OperationResult = res };
        }

        // GET: api/CustomerApi/add + customer
        [ActionName("add")]
        [HttpPost]
        public ApiResult AddOneCustomer(Customer customer)
        {
            logic.AddCustomer(customer.Name, customer.Adress, customer.PhoneNum, customer.EMail);
            return new ApiResult() { OperationResult = true };
        }

        // GET: api/CustomerApi/mod + customer
        [ActionName("mod")]
        [HttpPost]
        public ApiResult ModOneCustomer(Customer customer)
        {
            logic.ChangeCustomer(customer.Id, customer.Name, customer.Adress, customer.PhoneNum, customer.EMail);
            return new ApiResult() { OperationResult = true };
        }

    }
}
