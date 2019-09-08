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
                    return new Response(null, new List<string> { "Book with same Id already exists." }, 400);
            }
            BookList.Add(newBook);
            ConvertToJson(BookList);
            return new Response(BookList, new List<string> { "New Book Added successfully" }, 200);
        }

        public Response DeleteBook(int bookId)
        {
            foreach (var book in BookList)
            {
                if (book.Id == bookId)
                {
                    BookList.Remove(book);
                    ConvertToJson(BookList);
                    return new Response(null, new List<string> { "Book Deleted successfully." }, 200);
                }
            }
            return new Response(null, new List<string> { "Invalid Id, The Book Id you entered does not exist." }, 400);
        }

        public Response GetAllBooks()
        {
            return new Response(BookList, null, 200);
        }

        public Response GetBookById(int bookId)
        {
            foreach(var book in BookList)
            {
                if (book.Id == bookId)
                    return new Response(new List<Book> { book }, null, 200);
            }
            return new Response(null, new List<string> { "Invalid Id, The Book Id you entered does not exist." }, 400);
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
                    return new Response(null, new List<string> { "Book Details Updated Successfully." }, 200);
                }
            }
            return new Response(null, new List<string> { "Invalid Id, The Book Id you entered does not exist." }, 400);
        }
    }
}
