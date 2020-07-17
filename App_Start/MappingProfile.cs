using AutoMapper;
using MvcBookStore.Dtos;
using MvcBookStore.Models;

namespace MvcBookStore.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<BookDto, Book>();
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}