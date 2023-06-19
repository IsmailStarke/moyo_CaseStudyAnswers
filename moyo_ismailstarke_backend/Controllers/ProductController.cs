using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moyo_ismailstarke_backend.Models;
using moyo_ismailstarke_backend.ViewModels;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace moyo_ismailstarke_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly UserManager<User> _userManager;

        public ProductController(IRepository repository, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        //-------------------------------- Get All Products -----------------------------------
        [HttpGet]
        [Route("GetAllProducts")]
        public ActionResult GetAllProducts()
        {
            try
            {
                var results = _repository.GetAllProducts();

                dynamic products = results.Select(p => new
                {
                    p.productId,
                    p.description,
                    p.price,
                    p.productQuantity,
                    CategoryName = p.Category.description
                });

                return Ok(products);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        //-------------------------------- Get One Product -----------------------------------
        [HttpGet]
        [Route("GetProduct/{productId}")]
        public ActionResult GetProduct(int productId)
        {
            try
            {
                var product = _repository.GetProduct(productId);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch
            {
                return StatusCode(404, "Not Found");
            }
        }

        //-------------------------------- Update Product -----------------------------------
        [HttpPut]
        [Route("UpdateProduct/{productId}")]
        public ActionResult UpdateProduct(int productId, ProductViewModel updatedProduct)
        {
            try
            {
                var existingProduct = _repository.GetProduct(productId);

                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.price = updatedProduct.price;
                existingProduct.productQuantity = updatedProduct.productQuantity;

                _repository.SaveChanges();

                return Ok(existingProduct);
            }
            catch (Exception)
            {
                return StatusCode(400, "Bad Request");
            }
        }

    }
}
