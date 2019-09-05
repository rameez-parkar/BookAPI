using BookService.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.App.Model
{
    public class Validation
    {
        public bool isNegative(int value)
        {
            if (value < 0)
                return true;
            else
                return false;
        }

        public bool isAllAlphabet(string value)
        {
            if (value.Any(char.IsDigit))
                return false;
            else
                return true;
        }
    }
    public class BooksService : IBooksService
    {
        BookData bookData = new BookData();
        Validation validation = new Validation();

        public Response AddNewBook(Book newBook)
        {
            if (validation.isAllAlphabet(newBook.Name) && validation.isAllAlphabet(newBook.Category) && validation.isAllAlphabet(newBook.Author) && validation.isNegative(newBook.Id) == false && validation.isNegative(newBook.Price) == false)
                return bookData.AddNewBook(newBook);
            else
                return new Response(null, "Invalid Details, please ensure that Name, Category and Author contain only alphabets and Id and Price are positive numbers.");
        }

        public Response DeleteBook(int bookId)
        {
            if (validation.isNegative(bookId))
                return new Response(null, "Invalid Id, Id must be a positive number.");
            else
                return bookData.DeleteBook(bookId);
        }

        public Response GetAllBooks()
        {
            return bookData.GetAllBooks();
        }

        public Response GetBookById(int bookId)
        {
            if (validation.isNegative(bookId))
                return new Response(null, "Invalid Id, Id must be a positiive number.");
            else
                return bookData.GetBookById(bookId);
        }

        public Response UpdateData(int bookId, Book updatedData)
        {
            if (validation.isNegative(bookId))
                return new Response(null, "Invalid Id, Book Id should be a positive number.");
            else
            {
                if (validation.isAllAlphabet(updatedData.Name) && validation.isAllAlphabet(updatedData.Category) && validation.isAllAlphabet(updatedData.Author) && validation.isNegative(updatedData.Price) == false)
                    return bookData.UpdateData(bookId, updatedData);
                else
                    return new Response(null, "Invalid Details, please ensure that Name, Category and Author contain only alphabets and Id and Price are positive numbers.");
            }
        }
    }
}
