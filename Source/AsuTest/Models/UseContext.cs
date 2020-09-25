using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsuTest.Models
{
    public class UseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public UseContext(DbContextOptions<UseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}