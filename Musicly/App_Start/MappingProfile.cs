using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Musicly.Models;
using Musicly.DataTransferObjects;

namespace Musicly.App_Start
{
    public class MappingProfile : Profile
    {
        //map object to object so you dont have to define the props manually (convention based mapping tool)
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}