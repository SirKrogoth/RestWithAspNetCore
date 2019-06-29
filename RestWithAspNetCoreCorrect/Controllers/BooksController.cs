using Microsoft.AspNetCore.Mvc;
using RestWithAspNetCoreCorrect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetCoreCorrect.Controllers
{
    [Route("api/[Controller]")]
    public class BooksController : Controller
    {
        [HttpGet("v1")]
        public IActionResult Get()
        {
            //return OK(_bookBusiness.FindAll());
            return Ok();
        }

        [HttpGet("v1")]
        public IActionResult Get(long id)
        {
            /*var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();

            return Ok(book); */
            return Ok();
        }

        [HttpPost("v1")]
        public IActionResult Post([FromBody] Book book)
        {
            /*if (book == null) return BadRequest();
            return new ObjectResult(_bookBusiness.Create(book));*/
            return Ok();
        }

        [HttpPut("v1")]
        public IActionResult Put([FromBody] Book book)
        {
            /*if (book == null) return BadRequest();
            var updateBook = _bookBusiness.Update(book);
            if (updateBook == null) return BadRequest();
            return new ObjectResult(updateBook);*/

            return Ok();
        }

        [HttpDelete("v1/{id}")]
        public IActionResult Delete(int id)
        {
            /*_bookBusiness.Delete(id);
            return NoContent();*/
            return Ok();
        }
    }
}
