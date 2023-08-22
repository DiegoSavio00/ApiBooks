using ApiBooks.Application.DTOs.Book;
using ApiBooks.Application.DTOs.Category;
using ApiBooks.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBooks.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<BookDTO, Book>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
