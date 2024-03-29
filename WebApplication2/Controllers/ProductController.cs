﻿using Microsoft.AspNetCore.Mvc;
using OnlineWalmart.Products.DAL.Models;

namespace OnlineWalmart.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _ProductRepository;
        private readonly ProductContext _context;

        public ProductController(IProductRepository ProductStorage, ProductContext context)
        {
            _ProductRepository = ProductStorage;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Product>>> GetAllProducts()
        {
            return Ok(await _ProductRepository.GetAllProductsAsync());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ICollection<Product>>> GetProduct(Guid id)
        {
            var Product = await _ProductRepository.GetProductByIdAsync(id);

            if (Product is null)
                return NotFound($"Product with identity {id} could not be found.");

            return Ok(Product);
        }

        [HttpPost]
        public async Task<ActionResult<ICollection<Product>>> AddProduct(ProductModelToBePosted productModel)
        {
            var product = new Product
            {
                Id = new Guid(),
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                DeliveryInfo = productModel.DeliveryInfo
            };

            try
            {
                if (await _ProductRepository.AddNewProductAsync(product))
                {
                    if (!(await _context.SaveChangesAsync() > 0))
                    {
                        return StatusCode(500, "Product could not be saved.");
                    }
                }

                return StatusCode(201, product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }
    }
}
