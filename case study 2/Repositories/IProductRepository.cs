using WebApiProductCaseStudy.Models;
namespace WebApiProductCaseStudy.Repositories
{
    public interface IProductRepository
    {

        void AddProduct(Product obj);

        void deleteProduct(int id);

        void updateProduct(Product product);

        List<Product> GetProducts();

        Product GetProductsById(int id);

    }
}
