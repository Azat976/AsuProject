using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsuTest.Models
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public SelectList Statuss { get; set; }
        public string SelStatuss { get; set; }
    }
}
