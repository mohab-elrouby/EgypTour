using AutoMapper;
using Domain.DTO;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<LocalReview, LocalReviewDTO>().ReverseMap();
            CreateMap<ServiceReview, ServiceReviewDTO>().ReverseMap();
           

        }
    }
}
