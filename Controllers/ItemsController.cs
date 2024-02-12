using InterviewTask.BLL.Item;
using InterviewTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        [HttpGet]
        public IActionResult SearchItem()
        {
            try
            {
                return Ok(BLLItem.Search());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("SaveItem")]
        public IActionResult SaveItem([FromBody] ItemDTO itemDTO)
        {
            try
            {
                return Ok(BLLItem.SaveItem(itemDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("ItemDelete/{id:int}")]
        public IActionResult ItemDelete(int id)
        {
            try
            {
                return Ok(BLLItem.DeleteItem(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        [Route("GetItemByID/{id:int}")]
        public IActionResult GetItemByID(int id)
        {
            try
            {
                return Ok(BLLItem.GetItemByID(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
