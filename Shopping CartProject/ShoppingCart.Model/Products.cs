using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Model
{
    public class Products
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public double Price { get; set; }
        public double DiscountPercentage { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
     
        public ProductsCategories productsCategories { get; set; }
    }
}
