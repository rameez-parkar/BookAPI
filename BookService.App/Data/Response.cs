using System.Collections.Generic;

namespace BookService.App.Data
{
    public class Response
    {
        public List<Book> BookList;
        public string Message;
        public int StatusCode; 

        public Response(List<Book> books, string message, int statusCode)
        {
            this.BookList = books;
            this.Message = message;
            this.StatusCode = statusCode;
        }
    }
}
