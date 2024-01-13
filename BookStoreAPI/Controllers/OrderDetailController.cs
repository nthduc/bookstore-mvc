using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        // GET all order details
        public IActionResult GetOrderDetails()
        {
            var orderDetails = _unitOfWork.OrderDetail.GetAll(includeProperties: "OrderHeader,Product");
            return Ok(orderDetails);
        }


        [HttpGet("{id}")]
        // Get an order detail by Id
        public IActionResult GetOrderDetail(int id)
        {
            var orderDetail = _unitOfWork.OrderDetail.Get(o => o.Id == id, includeProperties: "OrderHeader,Product");
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        [HttpPost]
        // Create a new order detail
        public IActionResult CreateOrderDetail(OrderDetail orderDetail)
        {
            _unitOfWork.OrderDetail.Add(orderDetail);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetOrderDetail), new { id = orderDetail.Id }, orderDetail);
        }

        [HttpPut("{id}")]
        // Update an order detail
        public IActionResult UpdateOrderDetail(int id, OrderDetail orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return BadRequest();
            }
            _unitOfWork.OrderDetail.Update(orderDetail);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        // Delete an order detail
        public IActionResult DeleteOrderDetail(int id)
        {
            var orderDetail = _unitOfWork.OrderDetail.Get(o => o.Id == id);

            if (orderDetail == null)
            {
                return NotFound();
            }
            _unitOfWork.OrderDetail.Remove(orderDetail);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
