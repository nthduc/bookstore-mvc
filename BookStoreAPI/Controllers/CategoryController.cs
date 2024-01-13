using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        // GET all categories
        public IActionResult GetCategories()
        {
            var categories = _unitOfWork.Category.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        // Get a category by Id
        public IActionResult GetCategory(int id)
        {
            var category = _unitOfWork.Category.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        // Create a new category
        public IActionResult CreateCategory(Category category)
        {
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        // Update a category
        public IActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        // Delete a category
        public IActionResult DeleteCategory(int id)
        {
            var category = _unitOfWork.Category.Get(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
