using AutoMapper;
using E_BookStore_B.DTOs;
using E_BookStore_B.Models;

namespace E_BookStore_B.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, BookUpdateDto>().ReverseMap();
            CreateMap<Autor, AutorDTO>().ReverseMap();
            CreateMap<Izdavac, IzdavacDTO>().ReverseMap();
        }
    }
}
