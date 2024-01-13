using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        // GET all products
        public IActionResult GetProducts()
        {
            var products = _unitOfWork.Product.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        // Get a product by Id
        public IActionResult GetProduct(int id)
        {
            var product = _unitOfWork.Product.Get(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        // Create a new product
        public IActionResult CreateProduct(Product product)
        {
            _unitOfWork.Product.Add(product);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        // Update a product
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Product.Update(product);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        // Delete a product
        public IActionResult DeleteProduct(int id)
        {
            var product = _unitOfWork.Product.Get(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
