using BookService.App.Data;

namespace BookService.App.Model
{
    public interface IBooksService
    {
        Response GetAllBooks();
        Response GetBookById(int bookId);
        Response AddNewBook(Book newBook);
        Response UpdateData(int bookId, Book updatedData);
        Response DeleteBook(int bookId);
    }
}
