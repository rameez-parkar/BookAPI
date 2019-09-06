using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.App.Data;
using BookService.App.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BooksService booksService = new BooksService(); 
        // GET: api/Book
        [HttpGet]
        public ActionResult<Response> Get()
        {
            Response response = booksService.GetAllBooks();
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Response> Get(int id)
        {
            Response response = booksService.GetBookById(id);
            return StatusCode(response.StatusCode, response);
        }

        // POST: api/Book
        [HttpPost]
        public ActionResult<Response> Post([FromBody] Book value)
        {
            Response response = booksService.AddNewBook(value);
            return StatusCode(response.StatusCode, response);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public ActionResult<Response> Put(int id, [FromBody] Book value)
        {
            Response response = booksService.UpdateData(id, value);
            return StatusCode(response.StatusCode, response);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Response> Delete(int id)
        {
            Response response = booksService.DeleteBook(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
