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
        ILogic logic;
        IMapper mapper;
        public CustomerApiController()
        {
            logic = new Logic.Logic();
            mapper = MapperFactory.CreateMapper();
        }

        // GET: api/CustomerApi
        public IEnumerable<Models.Customer> Get()
        {
            var customers = logic.GetCustomerList();
            return mapper.Map<IList<Data.CUSTOMER>, List<Models.Customer>>(customers);
        }
    }
}
