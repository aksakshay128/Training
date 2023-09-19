using WebApiProductCaseStudy.Models;
using WebApiProductCaseStudy.Repositories;

namespace WebApiProductCaseStudy.Services

{
    public class ProductService : IProductService
    {

        IProductRepository _dbConext;

        public ProductService(IProductRepository dbContext)
        {
            _dbConext = dbContext;
        }
        public List<Product> GetProducts()
        {
            return _dbConext.GetProducts();
        }

        public Product GetProductsById(int id)
        {
            return _dbConext.GetProductsById(id);
        }

        public void AddProduct(Product ProductObj)
        {
            _dbConext.AddProduct(ProductObj);
        }

        public void updateProduct(Product product)
        {
            _dbConext.updateProduct(product);
        }
        public void deleteProduct(int id)
        {
            _dbConext.deleteProduct(id);
        }
        public List<Product> GetByCategory(string category)
        {
            return _dbConext.GetProducts().Where(i => i.Category == category).ToList();
        }



        public List<Product> OutofStock()
        {
            return _dbConext.GetProducts().Where(i => i.Quantity == 0).ToList();
        }



        public List<Product> GetByRange(int start, int end)
        {
            return _dbConext.GetProducts().Where(i => i.UnitPrice >= start && i.UnitPrice <= end).ToList();
        }



        public List<string> GetAllCategories()
        {
            return  _dbConext.GetProducts().Select(i => i.Category).Distinct().ToList();

        }


    }
}
