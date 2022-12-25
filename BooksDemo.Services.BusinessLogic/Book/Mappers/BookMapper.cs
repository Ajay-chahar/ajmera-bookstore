using AutoMapper;
using BooksDemo.Services.Contract.Dto;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDemo.Services.BusinessLogic.Book.Mappers
{
    internal class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<BookStore.Data.Models.Book, BookDto>();

            CreateMap<BookDto, BookStore.Data.Models.Book>();
        }
    }
}
