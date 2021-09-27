using AutoMapper;
using KamelijaWeb.Data.Entities;
using KamelijaWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamelijaWeb.Data
{
    public class KamMappingProfile:Profile
    {
        public KamMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o=>o.OrderId, ex=>ex.MapFrom(o =>o.Id))
                .ReverseMap();
        }
    }
}
