using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BooksDemo.Services.Contract.Dto
{
    public class BookDto
    {
        public string Name { get; set; }
        public string AuthorName { get; set; }
       
        public Guid Id { get; set; }
    }
}
