using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess
{
    public class ShoppingCartDbContext : IdentityDbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options)
            : base(options)
        { }

        public DbSet<Products> products { get; set; }
        public DbSet<ProductsCategories> productsCategories { get; set; }

    }
}
