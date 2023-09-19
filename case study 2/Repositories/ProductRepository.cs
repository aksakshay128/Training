using Microsoft.EntityFrameworkCore;
using WebApiProductCaseStudy.Models;
namespace WebApiProductCaseStudy.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDbContext _dbConext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbConext = dbContext;
        }
        public List<Product> GetProducts()
        {
            return _dbConext.Products.ToList();
        }

        public Product GetProductsById(int id)
        {
            return _dbConext.Products.Find(id);
        }

        public void AddProduct(Product ProductObj)
        {
            _dbConext.Products.Add(ProductObj);
            _dbConext.SaveChanges();
        }

        public void updateProduct(Product product)
        {
            _dbConext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbConext.SaveChanges();
        }

        public void deleteProduct(int id)
        {
            _dbConext.Products.Remove(GetProductsById(id));
            _dbConext.SaveChanges();
        }
    }
}




