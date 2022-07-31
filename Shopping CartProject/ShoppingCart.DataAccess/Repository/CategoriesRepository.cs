using ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess.Repository
{
    public class CategoriesRepository : IShoppingCartRepository<ProductsCategories>
    {
        ShoppingCartDbContext db;
        public CategoriesRepository(ShoppingCartDbContext _db)
        {
            db = _db;
        }

        public void Add(ProductsCategories entity)
        {
            db.productsCategories.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = Find(id);
            db.Remove(category);
            db.SaveChanges();
        }



        public ProductsCategories Find(int id)
        {
            var category = db.productsCategories.SingleOrDefault(c => c.Id == id);
            return category;
        }

        public IList<ProductsCategories> List()
        {
           return db.productsCategories.ToList();
        }



        public void Update(int id, ProductsCategories NewCategories)
        {
            db.Update(NewCategories);
            db.SaveChanges();

        }
    }
}
