using Microsoft.AspNetCore.Mvc;
using OnlineWalmart.Orders.DAL;
using OnlineWalmart.Orders.DAL.Context;
using OnlineWalmart.Orders.DAL.DTO;
using OnlineWalmart.Orders.DAL.Entities;
using OnlineWalmart.Orders.DAL.Interfaces;
using System.Text.Json;

namespace OnlineWalmart.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OrderContext _context;
        DiscountCode[] discountCodes = new DiscountCode[]
        {
            new DiscountCode("DISCOUNT5", 5),
            new DiscountCode("DISCOUNT10", 10),
            new DiscountCode("DISCOUNT50", 50),
        };

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
        public async Task<ActionResult<ICollection<Order>>> AddOrder(OrderModelForPosting orderModel)
        {
            try
            {
                #region HttpClient

                var userUrl = "https://localhost:7065/user";
                var productUrl = "https://localhost:7065/product";

                using var client = new HttpClient();

                var userResponse = await client.GetAsync(userUrl);
                var productResponse = await client.GetAsync(productUrl);

                if (!userResponse.IsSuccessStatusCode)
                    return NotFound();

                if (!productResponse.IsSuccessStatusCode)
                    return NotFound();

                var userContent = await userResponse.Content.ReadAsStringAsync();
                var productContent = await productResponse.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var users = JsonSerializer.Deserialize<ICollection<User>>(userContent, options);
                var products = JsonSerializer.Deserialize<ICollection<Product>>(productContent, options);

                #endregion

                if (UserDoesNotExist(orderModel, users!) && ProductDoesNotExist(orderModel, products!))
                    return StatusCode(500, "User and product cannot be found. User and product identity not valid");

                if (UserDoesNotExist(orderModel, users!))
                    return StatusCode(500, "User cannot be found. User identity is not valid");

                if (ProductDoesNotExist(orderModel, products!))
                    return StatusCode(500, "Product cannot be found. Product identity is not valid");

                var orderEntity = new Order
                {
                    ProductId = orderModel.ProductId,
                    UserId = orderModel.UserId,
                    DateOfPurchase = new DateTimeOffset(DateTime.Now),
                };

                new DiscountCodeValidator().Validate(orderModel.DiscountCode, discountCodes, orderEntity);

                if (await _orderRepository.AddNewOrderAsync(orderEntity))
                {
                    if (!(await _context.SaveChangesAsync() > 0))
                        return StatusCode(500, "Order could not be saved.");
                }

                return StatusCode(201, orderEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }

        private static bool ProductDoesNotExist(OrderModelForPosting orderModel, ICollection<Product> products)
        {
            return !products!.Any(product => product.Id == orderModel.ProductId);
        }

        private static bool UserDoesNotExist(OrderModelForPosting orderModel, ICollection<User> users)
        {
            return !users!.Any(user => user.Id == orderModel.UserId);
        }
    }
}
