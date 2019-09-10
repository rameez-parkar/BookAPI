using System;
using System.Collections.Generic;
using BookService.App.Data;
using BookService.App.Middleware.WebApplication1;
using BookService.App.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookService.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BooksService booksService = new BooksService();

        // GET: api/Books
        [HttpGet]
        public ActionResult<Response> Get()
        {
            Response response = booksService.GetAllBooks();
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Response> Get(int id)
        {
            Response response = booksService.GetBookById(id);
            return StatusCode(response.StatusCode, response);
        }

        // POST: api/Books
        [HttpPost]
        [ValidateModelStateFilter]
        public ActionResult<Response> Post([FromBody] Book value)
        {
            List<string> response_message = new List<string>();

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values)
                    response_message.Add(error.ToString());
                return StatusCode(400, response_message);
            }
            else
            {
                Response response = booksService.AddNewBook(value);
                return StatusCode(response.StatusCode, response);
            }
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        [ValidateModelStateFilter]
        public ActionResult<Response> Put(int id, [FromBody] Book value)
        {
            List<string> response_message = new List<string>();

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values)
                    response_message.Add(error.ToString());
                return StatusCode(400, response_message);
            }
            else
            {
                Response response = booksService.UpdateData(id, value);
                return StatusCode(response.StatusCode, response);
            }
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
