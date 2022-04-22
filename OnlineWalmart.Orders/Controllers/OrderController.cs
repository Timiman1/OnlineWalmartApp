using Microsoft.AspNetCore.Mvc;
using OnlineWalmart.Orders.DAL.Context;
using OnlineWalmart.Orders.DAL.Entities;
using OnlineWalmart.Orders.DAL.Interfaces;

namespace OnlineWalmart.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OrderContext _context;

        public OrderController(IOrderRepository orderStorage, OrderContext context)
        {
            _orderRepository = orderStorage;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Order>>> GetAllOrders()
        {
            return Ok(await _orderRepository.GetAllOrdersAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ICollection<Order>>> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            if (order is null)
                return NotFound($"Order with identity {id} could not be found.");

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<ICollection<Order>>> AddOrder(Order order)
        {
            try
            {
                if (await _orderRepository.AddNewOrderAsync(order))
                {
                    if (!(await _context.SaveChangesAsync() > 0))
                    {
                        return StatusCode(500, "Order could not be saved.");
                    }
                }

                return StatusCode(201, order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }
    }
}
