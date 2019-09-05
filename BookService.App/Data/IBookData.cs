namespace BookService.App.Data
{
    public interface IBookData
    {
        Response GetAllBooks();
        Response GetBookById(int bookId);
        Response AddNewBook(Book newBook);
        Response UpdateData(int bookId, Book updatedData);
        Response DeleteBook(int bookId);
    }
}
