using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // 1 Orderheader one - many OrderDetail
    public class OrderHeaderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderHeaderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        // GET all order headers
        public IActionResult GetOrderHeaders()
        {
            var orderHeaders = _unitOfWork.OrderHeader.GetAll();
            return Ok(orderHeaders);
        }

        [HttpGet("{id}")]
        // Get an order header by Id
        public IActionResult GetOrderHeader(int id)
        {
            var orderHeader = _unitOfWork.OrderHeader.Get(o => o.Id == id);
            if (orderHeader == null)
            {
                return NotFound();
            }
            return Ok(orderHeader);
        }

        [HttpPost]
        // Create a new order header
        public IActionResult CreateOrderHeader(OrderHeader orderHeader)
        {
            _unitOfWork.OrderHeader.Add(orderHeader);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetOrderHeader), new { id = orderHeader.Id }, orderHeader);
        }

        [HttpPut("{id}")]
        // Update an order header
        public IActionResult UpdateOrderHeader(int id, OrderHeader orderHeader)
        {
            if (id != orderHeader.Id)
            {
                return BadRequest();
            }
            _unitOfWork.OrderHeader.Update(orderHeader);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        // Delete an order header
        public IActionResult DeleteOrderHeader(int id)
        {
            var orderHeader = _unitOfWork.OrderHeader.Get(o => o.Id == id);

            if (orderHeader == null)
            {
                return NotFound();
            }
            _unitOfWork.OrderHeader.Remove(orderHeader);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
