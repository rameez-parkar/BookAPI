using BookService.App.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.App.Model
{
    public class BooksService : IBooksService
    {
        BookData _bookData = new BookData();
        Validation _validation = new Validation();
        List<string> _message = new List<string>();

        public Response AddNewBook(Book newBook)
        {
            int validationCount = 0;
            if (!_validation.IsAllAlphabet(newBook.Name))
            {
                validationCount++;
                _message.Add("Invalid Book Name. It must only contain alphabets.");
            }
            if (!_validation.IsAllAlphabet(newBook.Category))
            {
                validationCount++;
                _message.Add("Invalid Book Category. It must only contain alphabets.");
            }
            if (!_validation.IsAllAlphabet(newBook.Author))
            {
                validationCount++;
                _message.Add("Invalid Author Name. It must only contain alphabets.");
            }
            if (_validation.IsNegative(newBook.Id))
            {
                validationCount++;
                _message.Add("Invalid Book ID. It must be a positive number.");
            }
            if (_validation.IsNegative(newBook.Price))
            {
                validationCount++;
                _message.Add("Invalid Book Price. It must be a positive value.");
            }

            if(validationCount == 0)
                return _bookData.AddNewBook(newBook);
            else
                return new Response(null, _message, 400);
        }

        public Response DeleteBook(int bookId)
        {
            if (_validation.IsNegative(bookId))
                return new Response(null, new List<string> { "Invalid Id, Id must be a positive number." }, 400);
            else
                return _bookData.DeleteBook(bookId);
        }

        public Response GetAllBooks()
        {
            return _bookData.GetAllBooks();
        }

        public Response GetBookById(int bookId)
        {
            if (_validation.IsNegative(bookId))
                return new Response(null, new List<string> { "Invalid Id, Id must be a positiive number." }, 400);
            else
                return _bookData.GetBookById(bookId);
        }

        public Response UpdateData(int bookId, Book updatedData)
        {
            if (_validation.IsNegative(bookId))
                return new Response(null, new List<string> { "Invalid Id, Book Id should be a positive number." }, 400);
            else
            {
                int validationCount = 0;
                if (!_validation.IsAllAlphabet(updatedData.Name))
                {
                    validationCount++;
                    _message.Add("Invalid Book Name. It must only contain alphabets.");
                }
                if (!_validation.IsAllAlphabet(updatedData.Category))
                {
                    validationCount++;
                    _message.Add("Invalid Book Category. It must only contain alphabets.");
                }
                if (!_validation.IsAllAlphabet(updatedData.Author))
                {
                    validationCount++;
                    _message.Add("Invalid Author Name. It must only contain alphabets.");
                }
                if (_validation.IsNegative(updatedData.Price))
                {
                    validationCount++;
                    _message.Add("Invalid Book Price. It must be a positive value.");
                }

                if (validationCount == 0)
                    return _bookData.UpdateData(bookId, updatedData);
                else
                    return new Response(null, _message, 400);
            }
        }
    }
}
