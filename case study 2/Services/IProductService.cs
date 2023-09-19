using WebApiProductCaseStudy.Models;

namespace WebApiProductCaseStudy.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product GetProductsById(int id);

        void AddProduct(Product obj);

        void updateProduct(Product product);
        List<Product> GetByCategory(string catagory);

        void deleteProduct(int id);
        List<Product> OutofStock();
        List<Product> GetByRange(int start, int end);
        List<string> GetAllCategories();

    }
}
