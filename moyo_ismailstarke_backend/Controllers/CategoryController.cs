using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using moyo_ismailstarke_backend.Models;
using moyo_ismailstarke_backend.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace moyo_ismailstarke_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository _repository;

        public CategoryController(IRepository repository)
        {
            _repository = repository;
        }

        //-------------------------------- Get All Categories -----------------------------------
        [HttpGet]
        [Route("GetAllCategories")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[Authorize(Roles = "Admin, Customer")]
        public ActionResult<Category[]> GetAllCategories()
        {
            try
            {
                var categories = _repository.GetAllCategories();
                return Ok(categories);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        //-------------------------------- Get One Category -----------------------------------
        [HttpGet]
        [Route("GetCategory/{categoryId}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[Authorize(Roles = "Admin, Customer")]
        public ActionResult<Category> GetCategory(int categoryId)
        {
            try
            {
                var category = _repository.GetCategory(categoryId);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch(Exception)
            {
                return StatusCode(404, "Not Found");
            }
        }

        //-------------------------------- Create Category -----------------------------------
        [HttpPost]
        [Route("CreateCategory")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public ActionResult<Category> CreateCategory(CategoryViewModel cvm)
        {
            try
            {
                var newCategory = new Category
                {
                    description = cvm.description
                };

                _repository.Add(newCategory);
                _repository.SaveChanges();

                return Ok(newCategory);
            }
            catch (Exception)
            {
                return StatusCode(400, "Bad Request");
            }
        }


        //-------------------------------- Update Category -----------------------------------
        [HttpPut]
        [Route("UpdateCategory")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public ActionResult<Category> UpdateCategory(int categoryId, CategoryViewModel updatedCategory)
        {
            try
            {
                var existingCategory = _repository.GetCategory(categoryId);

                if (existingCategory == null)
                {
                    return NotFound();
                }

                existingCategory.description = updatedCategory.description;

                _repository.SaveChanges();

                return Ok(existingCategory);
            }
            catch (Exception)
            {
                return StatusCode(400, "Bad Request");
            }
        }

        //-------------------------------- Delete Category -----------------------------------
        [HttpDelete]
        [Route("DeleteCategory")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCategory(int categoryId)
        {
            try
            {
                var category = _repository.GetCategory(categoryId);

                if (category == null)
                {
                    return NotFound();
                }

                _repository.Delete(category);
                _repository.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(categoryId);
            }
        }
    }
}
