using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        // GET all shopping carts (giỏ hàng)
        public IActionResult GetShoppingCarts()
        {
            var shoppingCarts = _unitOfWork.ShoppingCart.GetAll();
            return Ok(shoppingCarts);
        }

        [HttpGet("{id}")]
        // Get a shopping cart by Id
        public IActionResult GetShoppingCart(int id)
        {
            var shoppingCart = _unitOfWork.ShoppingCart.Get(s => s.Id == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            return Ok(shoppingCart);
        }

        [HttpPost]
        // Create a new shopping cart
        public IActionResult CreateShoppingCart(ShoppingCart shoppingCart)
        {
            _unitOfWork.ShoppingCart.Add(shoppingCart);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetShoppingCart), new { id = shoppingCart.Id }, shoppingCart);
        }

        [HttpPut("{id}")]
        // Update a shopping cart
        public IActionResult UpdateShoppingCart(int id, ShoppingCart shoppingCart)
        {
            if (id != shoppingCart.Id)
            {
                return BadRequest();
            }
            _unitOfWork.ShoppingCart.Update(shoppingCart);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        // Delete a shopping cart
        public IActionResult DeleteShoppingCart(int id)
        {
            var shoppingCart = _unitOfWork.ShoppingCart.Get(s => s.Id == id);

            if (shoppingCart == null)
            {
                return NotFound();
            }
            _unitOfWork.ShoppingCart.Remove(shoppingCart);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
