using Microsoft.AspNetCore.Http;
using WebApiProductCaseStudy.Services;
using Microsoft.AspNetCore.Mvc;
using WebApiProductCaseStudy.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApiProductCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private IProductService _ProductService;

        public ProductController(IProductService productService)
        {
            _ProductService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_ProductService.GetProducts());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product obj)
        {
            _ProductService.AddProduct(obj);
            return Ok(new { result = "Product Details added to db" });
        }

        [HttpPut]
        public IActionResult Edit(Product product)
        {
            _ProductService.updateProduct(product);
            return Ok(new { result = "Updated product" });
        }

        [HttpDelete]
        public IActionResult DeleteProducts(int id)
        {
            _ProductService.deleteProduct(id);
            return Ok(new { result = "Deleted Product" });
        }



        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            Product obj = _ProductService.GetProductsById(id);

            if (obj == null)
            {
                return NotFound(new { result = "Requested product details are not available." });
            }
            else
            {
                return Ok(obj);
            }
        }



        [HttpGet("catagory")]
        public IActionResult GetbyCategory(string catagory)
        {
            return Ok(_ProductService.GetByCategory(catagory));
        }
 
        [HttpGet("Categories")]
        public IActionResult GetAllCategories()
        {
            return Ok(_ProductService.GetAllCategories());
        }



        [HttpGet("OutofStock")]
        public IActionResult getOutofStock()
        {
            return Ok(_ProductService.OutofStock());
        }



        [HttpGet("Range")]
        public IActionResult getByRange(int start, int end)
        {
            return Ok(_ProductService.GetByRange(start, end));
        }
    }
}
