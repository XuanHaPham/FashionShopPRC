using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionShopApi.Models
{
    public class FashionShopContext : DbContext
    {
        public FashionShopContext(DbContextOptions<FashionShopContext> options) : base(options)
        {

        }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
