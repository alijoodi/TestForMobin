using AutoMapper;
using Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.AuthorDtos;
using ViewModels.BookDtos;

namespace Services.AutoMapperProfiles
{
    public class AuthorMapperProfile : Profile
    {
        public AuthorMapperProfile()
        {
            CreateMap<Author, AuthorResponse>().ReverseMap();
            CreateMap<Author, AuthorAddRequest>().ReverseMap();
            CreateMap<Author, AuthorAddResponse>().ReverseMap();
            CreateMap<AuthorAddRequest, AuthorAddResponse>().ReverseMap();
        }
    }
}
