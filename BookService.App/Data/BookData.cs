using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BookService.App.Data
{
    public class BookData : IBookData
    {
        List<Book> BookList = new List<Book>();
        public BookData()
        {
            LoadJsonFile();
        }

        public void LoadJsonFile()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\rparkar\Desktop\Assignments\BookService\BookService.App\Data\BookData.json"))
            {
                string json = r.ReadToEnd();
                BookList = JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }

        public void ConvertToJson(List<Book> Books)
        {
            string json = JsonConvert.SerializeObject(BookList.ToArray());
            File.WriteAllText(@"C:\Users\rparkar\Desktop\Assignments\BookService\BookService.App\Data\BookData.json", json);
        }

        public Response AddNewBook(Book newBook)
        {
            foreach(var book in BookList)
            {
                if (book.Id == newBook.Id)
                    return new Response(null, "Book with samme Id already exists.");
            }
            BookList.Add(newBook);
            ConvertToJson(BookList);
            return new Response(BookList, "New Book Added successfully");
        }

        public Response DeleteBook(int bookId)
        {
            foreach (var book in BookList)
            {
                if (book.Id == bookId)
                {
                    BookList.Remove(book);
                    ConvertToJson(BookList);
                    return new Response(null, "Book Deleted successfully.");
                }
            }
            return new Response(null, "Invalid Id, The Book Id you entered does not exist.");
        }

        public Response GetAllBooks()
        {
            return new Response(BookList, null);
        }

        public Response GetBookById(int bookId)
        {
            foreach(var book in BookList)
            {
                if (book.Id == bookId)
                    return new Response(new List<Book> { book }, null);
            }
            return new Response(null, "Invalid Id, The Book Id you entered does not exist.");
        }

        public Response UpdateData(int bookId, Book updatedData)
        {
            foreach(var book in BookList)
            {
                if(book.Id == bookId)
                {
                    book.Name = updatedData.Name;
                    book.Price = updatedData.Price;
                    book.Author = updatedData.Author;
                    book.Category = updatedData.Category;
                    ConvertToJson(BookList);
                    return new Response(null, "Book Details Updated Successfully.");
                }
            }
            return new Response(null, "Invalid Id, The Book Id you entered does not exist.");
        }
    }
}
