using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EcommerceApi.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options){ }
        public DbSet<Product> Products{get; set;}
        
    }
}