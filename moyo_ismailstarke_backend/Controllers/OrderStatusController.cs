using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moyo_ismailstarke_backend.Models;
using moyo_ismailstarke_backend.ViewModels;
using System.Data;

namespace moyo_ismailstarke_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly IRepository _repository;

        public OrderStatusController(IRepository repository)
        {
            _repository = repository;
        }

        //-------------------------------- Get All Statuses -----------------------------------
        [HttpGet]
        [Route("GetAllOrderStatuses")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public ActionResult<OrderStatus[]> GetAllOrderStatuses()
        {
            try
            {
                var statuses = _repository.GetAllOrderStatuses();
                return Ok(statuses);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        //-------------------------------- Create Status -----------------------------------
        [HttpPost]
        [Route("CreateStatus")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public ActionResult<OrderStatus> CreateOrderStatus(OrderStatusViewModel osvm)
        {
            try
            {
                var newStatus = new OrderStatus
                {
                    Status = osvm.status
                };

                _repository.Add(newStatus);
                _repository.SaveChanges();

                return Ok(newStatus);
            }
            catch (Exception)
            {
                return StatusCode(400, "Bad Request");
            }
        }

    }
}
