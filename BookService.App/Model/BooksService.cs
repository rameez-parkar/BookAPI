using BookService.App.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.App.Model
{
    public class BooksService : IBooksService
    {
        BookData bookData = new BookData();
        Validation validation = new Validation();

        public Response AddNewBook(Book newBook)
        {
            if (!validation.IsAllAlphabet(newBook.Name))
                return new Response(null, "Invalid Book Name. It must only contain alphabets.", 400);
            if(!validation.IsAllAlphabet(newBook.Category))
                return new Response(null, "Invalid Book Category. It must only contain alphabets.", 400);
            if(!validation.IsAllAlphabet(newBook.Author))
                return new Response(null, "Invalid Author Name. It must only contain alphabets.", 400);
            if(validation.IsNegative(newBook.Id))
                return new Response(null, "Invalid Book ID. It must be a positive number.", 400);
            if(validation.IsNegative(newBook.Price))
                return new Response(null, "Invalid Book Price. It must be a positive value.", 400);
            return bookData.AddNewBook(newBook);
        }

        public Response DeleteBook(int bookId)
        {
            if (validation.IsNegative(bookId))
                return new Response(null, "Invalid Id, Id must be a positive number.", 400);
            else
                return bookData.DeleteBook(bookId);
        }

        public Response GetAllBooks()
        {
            return bookData.GetAllBooks();
        }

        public Response GetBookById(int bookId)
        {
            if (validation.IsNegative(bookId))
                return new Response(null, "Invalid Id, Id must be a positiive number.", 400);
            else
                return bookData.GetBookById(bookId);
        }

        public Response UpdateData(int bookId, Book updatedData)
        {
            if (validation.IsNegative(bookId))
                return new Response(null, "Invalid Id, Book Id should be a positive number.", 400);
            else
            {
                if (!validation.IsAllAlphabet(updatedData.Name))
                    return new Response(null, "Invalid Book Name. It must only contain alphabets.", 400);
                if (!validation.IsAllAlphabet(updatedData.Category))
                    return new Response(null, "Invalid Book Category. It must only contain alphabets.", 400);
                if (!validation.IsAllAlphabet(updatedData.Author))
                    return new Response(null, "Invalid Author Name. It must only contain alphabets.", 400);
                if (validation.IsNegative(updatedData.Price))
                    return new Response(null, "Invalid Book Price. It must be a positive value.", 400);
                return bookData.UpdateData(bookId, updatedData);
            }
        }
    }
}
