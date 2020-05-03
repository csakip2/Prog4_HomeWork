using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transporter.Web.Models
{
    public class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Transporter.Data.CUSTOMER, Transporter.Web.Models.Customer>().
                ForMember(dest => dest.Id, map => map.MapFrom(src => src.CUSTOMER_ID)).
                ForMember(dest => dest.Name, map => map.MapFrom(src => src.CNAME)).
                ForMember(dest => dest.Adress, map => map.MapFrom(src => src.CADRESS)).
                ForMember(dest => dest.PhoneNum, map => map.MapFrom(src => src.CPHONE_NUM == null ? "" : src.CPHONE_NUM)).
                ForMember(dest => dest.EMail, map => map.MapFrom(src => src.CE_MAIL));
            });

            return config.CreateMapper();
        }
    }
}