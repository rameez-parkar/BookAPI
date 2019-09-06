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
            if (validation.IsAllAlphabet(newBook.Name) && validation.IsAllAlphabet(newBook.Category) && validation.IsAllAlphabet(newBook.Author) && validation.IsNegative(newBook.Id) == false && validation.IsNegative(newBook.Price) == false)
                return bookData.AddNewBook(newBook);
            else
                return new Response(null, "Invalid Details, please ensure that Name, Category and Author contain only alphabets and Id and Price are positive numbers.");
        }

        public Response DeleteBook(int bookId)
        {
            if (validation.IsNegative(bookId))
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
            if (validation.IsNegative(bookId))
                return new Response(null, "Invalid Id, Id must be a positiive number.");
            else
                return bookData.GetBookById(bookId);
        }

        public Response UpdateData(int bookId, Book updatedData)
        {
            if (validation.IsNegative(bookId))
                return new Response(null, "Invalid Id, Book Id should be a positive number.");
            else
            {
                if (validation.IsAllAlphabet(updatedData.Name) && validation.IsAllAlphabet(updatedData.Category) && validation.IsAllAlphabet(updatedData.Author) && validation.IsNegative(updatedData.Price) == false)
                    return bookData.UpdateData(bookId, updatedData);
                else
                    return new Response(null, "Invalid Details, please ensure that Name, Category and Author contain only alphabets and Id and Price are positive numbers.");
            }
        }
    }
}
