using System.Collections.Generic;

namespace BookService.App.Data
{
    public class Response
    {
        public List<Book> BookList;
        public string Message;

        public Response(List<Book> books, string message)
        {
            this.BookList = books;
            this.Message = message;
        }
    }
}
