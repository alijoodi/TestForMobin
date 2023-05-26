using AutoMapper;
using Models.Classes;
using ViewModels.BookDtos;

namespace Services.AutoMapperProfiles
{
    public class BookMapperProfile : Profile
    {
        public BookMapperProfile()
        {
            CreateMap<BookListResponse, Book>().ReverseMap();
            CreateMap<BookAddRequest, Book>().ReverseMap();
            CreateMap<BookAddResponse, Book>().ReverseMap();
            CreateMap<BookAddResponse, BookAddRequest>().ReverseMap();
        }
    }
}
