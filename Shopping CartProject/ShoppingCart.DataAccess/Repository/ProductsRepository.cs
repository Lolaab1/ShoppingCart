using ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess.Repository
{
    public class ProductsRepository : IShoppingCartRepository<Products>
    {
        ShoppingCartDbContext db;

        public ProductsRepository(ShoppingCartDbContext _db)
        {
            this.db = _db;
        }

        public void Add(Products entity)
        {
            db.products.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {

            var products = Find(id);
            db.products.Remove(products);
            db.SaveChanges();
        }

        public Products Find(int id)
        {
           var product = db.products.SingleOrDefault(p => p.Id == id);
            return product;
        }

        public IList<Products> List()
        {
            return db.products.ToList();
        }

        public void Update(int id, Products NewProduct)
        {
            db.Update(NewProduct);
            db.SaveChanges();
        }
    }
}
