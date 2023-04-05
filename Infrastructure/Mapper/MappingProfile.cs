using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() { 
        CreateMap<Comment,CommentDTO>().ReverseMap();
        CreateMap<LocalPerson,LocalPersonDTO>().ReverseMap();
        CreateMap<Activity,ActivityDTO>().ReverseMap();
        CreateMap<Messege,MessageDTO>().ReverseMap();  
        CreateMap<ToDoItem,ToDoItemDTO>().ReverseMap();
        }
    }
}
