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
        public Response Get()
        {
            return booksService.GetAllBooks();
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public Response Get(int id)
        {
            return booksService.GetBookById(id);
        }

        // POST: api/Book
        [HttpPost]
        public Response Post([FromBody] Book value)
        {
            return booksService.AddNewBook(value);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public Response Put(int id, [FromBody] Book value)
        {
            return booksService.UpdateData(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            return booksService.DeleteBook(id);
        }
    }
}
