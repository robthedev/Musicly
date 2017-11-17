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
            //Domain object to dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Song, SongDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            //dto to domain object
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<SongDto, Song>()
                .ForMember(s => s.Id, opt => opt.Ignore());

            //Mapper.CreateMap<MembershipTypeDto, MembershipType>()
            //   .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}