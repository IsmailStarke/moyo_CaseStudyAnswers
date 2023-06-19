using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using moyo_ismailstarke_backend.Models;
using moyo_ismailstarke_backend.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace moyo_ismailstarke_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly UserManager<User> _userManager;

        public StoreController(IRepository repository, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        //------------------------------- Place Order -------------------------------------
        [HttpPost]
        [Route("PlaceOrder")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [AllowAnonymous]
        public ActionResult PlaceOrder(OrderViewModel ovm)
        {
            var orderStatus = _repository.GetAllOrderStatuses().FirstOrDefault();

            if (orderStatus == null)
            {
                return BadRequest("No order status found");
            }

            //Create a new order instance and populate its properties
            var order = new Order
            {
                OrderDate = DateTime.Now,
                UserName = ovm.emailaddress,
                OrderStatusId = orderStatus.OrderStatusId,
                TotalPrice = CalculateTotalPrice(ovm.productId, ovm.quantity)
            };

            // Create OrderItems for each product in the order
            for (int i = 0; i < ovm.productId.Length; i++)
            {
                var productId = ovm.productId[i];
                var quantity = ovm.quantity[i];

                var product = _repository.GetProduct(productId);
                if (product == null)
                {
                    // Handle case where the product is not found
                    return BadRequest("Invalid product ID");
                }

                if (product.productQuantity < quantity)
                {
                    // Handle case where the requested quantity is greater than the available quantity
                    return BadRequest("Insufficient product quantity");
                }

                var orderItem = new OrderItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = product.price
                };

                order.OrderItem = orderItem;

                // Update the quantity of the product in the Products table
                product.productQuantity -= quantity;
            }

            // Save the order to the database
            _repository.Add(order);
            _repository.SaveChanges();

            // Return a success response
            return Ok("Order placed successfully");

        }

        //-------------------- Calculate the Total Price -----------------------

        private decimal CalculateTotalPrice(int[] productIds, int[] quantities)
        {
            decimal totalPrice = 0;

            for (int i = 0; i < productIds.Length; i++)
            {
                var product = _repository.GetProduct(productIds[i]);
                if (product == null)
                {
                    // Handle case where the product is not found
                    throw new Exception("Invalid product ID");
                }

                totalPrice += product.price * quantities[i];
            }

            return totalPrice;
        }

        //-------------------- Get All Orders -----------------
        [HttpGet]
        [Route("GetAllOrders")]
        public ActionResult GetAllOrders()
        {
            try
            {
                var orders = _repository.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
