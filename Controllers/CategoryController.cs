using InterviewTask.BLL.Category;
using InterviewTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult SearchCategory()
        {
            try
            {
                return Ok(BLLCategory.Search());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("SaveCategory")]
        public IActionResult SaveCategory([FromBody] ItemCategoryDTO categoryDTO)
        {
            try
            {
                return Ok(BLLCategory.SaveCategory(categoryDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("CategoryDelete/{id:int}")]
        public IActionResult CategoryDelete(int id)
        {
            try
            {
                return Ok(BLLCategory.DeleteCategory(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
