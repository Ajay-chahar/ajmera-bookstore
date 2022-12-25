using System;
using System.Collections.Generic;

namespace BookStore.Data.Models;

public partial class Book
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Authorname { get; set; }
}
