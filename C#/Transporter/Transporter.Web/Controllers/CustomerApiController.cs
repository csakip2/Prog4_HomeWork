using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Transporter.Logic;

namespace Transporter.Web.Controllers
{
    public class CustomerApiController : ApiController
    {
        ILogic logic;
        IMapper mapper;
    }
}
