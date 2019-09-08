using BookService.App.Data;
using BookService.App.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Xunit;
using FluentAssertions;

namespace BookService.Test
{
    public class BookServiceTest
    {
        BooksService booksService = new BooksService();
        List<Book> BookList = new List<Book>();

        [Fact]
        public void Check_For_Getting_All_Books()
        {
            LoadJsonFile();
            var expected = new Response(BookList, null, 200);
            var actual = booksService.GetAllBooks();
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Getting_Book_By_Id()
        {
            Book book = new Book { Id = 1, Name = "Harry Potter", Category = "Fiction", Author = "JK Rowling", Price = 500 };
            var expected = new Response(new List<Book> { book }, null, 200);
            var actual = booksService.GetBookById(1);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Getting_Book_By_Id_With_Negative_Id()
        {
            var expected = new Response(null, new List<string> { "Invalid Id, Id must be a positiive number." }, 400);
            var actual = booksService.GetBookById(-1);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Getting_Book_By_Id_With_Invalid_Id()
        {
            var expected = new Response(null, new List<string>{"Invalid Id, The Book Id you entered does not exist."}, 400);
            var actual = booksService.GetBookById(8);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Adding_New_Book()
        {
            Book book = new Book { Id = 2, Name = "Sherlock Holmes", Category = "Mystery", Author = "Arthur Conan Doyle", Price = 400 };
            var actual = booksService.AddNewBook(book);
            LoadJsonFile();
            var expected = new Response(BookList, new List<string> { "New Book Added successfully" }, 200);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Adding_New_Book_With_Existing_Id()
        {
            Book book = new Book { Id = 3, Name = "The Fault in our Stars", Category = "Romance", Author = "John Green", Price = 350 };
            var actual = booksService.AddNewBook(book);
            var expected = new Response(null, new List<string> { "Book with same Id already exists." }, 400);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Adding_New_Book_With_Invalid_Name()
        {
            Book book = new Book { Id = 10, Name = "Sherlock Holmes324", Category = "Mystery", Author = "Arthur Conan Doyle", Price = 400 };
            var expected = new Response(null, new List<string> { "Invalid Book Name. It must only contain alphabets." }, 400);
            var actual = booksService.AddNewBook(book);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Adding_New_Book_With_Invalid_Category()
        {
            Book book = new Book { Id = 11, Name = "Sherlock Holmes", Category = "Mys@$34tery", Author = "Arthur Conan Doyle", Price = 400 };
            var expected = new Response(null, new List<string> { "Invalid Book Category. It must only contain alphabets." }, 400);
            var actual = booksService.AddNewBook(book);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Adding_New_Book_With_Invalid_Author()
        {
            Book book = new Book { Id = 12, Name = "Sherlock Holmes", Category = "Mystery", Author = "Arthur C#*%3434onan Doyle", Price = 400 };
            var expected = new Response(null, new List<string> { "Invalid Author Name. It must only contain alphabets." }, 400);
            var actual = booksService.AddNewBook(book);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Adding_New_Book_With_Invalid_Id()
        {
            Book book = new Book { Id = -13, Name = "Sherlock Holmes", Category = "Mystery", Author = "Arthur Conan Doyle", Price = 400 };
            var expected = new Response(null, new List<string> { "Invalid Book ID. It must be a positive number." }, 400);
            var actual = booksService.AddNewBook(book);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Adding_New_Book_With_Invalid_Price()
        {
            Book book = new Book { Id = 14, Name = "Sherlock Holmes", Category = "Mystery", Author = "Arthur Conan Doyle", Price = -400 };
            var expected = new Response(null, new List<string> { "Invalid Book Price. It must be a positive value." }, 400);
            var actual = booksService.AddNewBook(book);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Updating_Book_Details()
        {
            Book book = new Book { Id = 4, Name = "Outliers", Category = "Business and Non Fiction", Author = "Martin Fowler", Price = 500 };
            var actual = booksService.UpdateData(4, book);
            var expected = new Response(null, new List<string> { "Book Details Updated Successfully." }, 200);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Updating_Book_Details_With_Negative_Id()
        {
            Book book = new Book { Id = -2, Name = "Sherlock Holmes", Category = "Mystery and Adventure", Author = "Arthur Conan Doyle", Price = 500 };
            var expected = new Response(null, new List<string> { "Invalid Id, Book Id should be a positive number." }, 400);
            var actual = booksService.UpdateData(-2, book);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Updating_Book_Details_With_Invalid_Id()
        {
            Book book = new Book { Id = 23, Name = "Sherlock Holmes", Category = "Mystery and Adventure", Author = "Arthur Conan Doyle", Price = 500 };
            var expected = new Response(null, new List<string> { "Invalid Id, The Book Id you entered does not exist." }, 400);
            var actual = booksService.UpdateData(23, book);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Updating_Book_Details_With_Invalid_Name()
        {
            Book book = new Book { Id = 1, Name = "Sherlock Holmes435", Category = "Mystery and Adventure", Author = "Arthur Conan Doyle", Price = 500 };
            var expected = new Response(null, new List<string> { "Invalid Book Name. It must only contain alphabets." }, 400);
            var actual = booksService.UpdateData(1, book);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Updating_Book_Details_With_Invalid_Category()
        {
            Book book = new Book { Id = 1, Name = "Sherlock Holmes", Category = "Mystery #%^454and Adventure", Author = "Arthur Conan Doyle", Price = 500 };
            var expected = new Response(null, new List<string> { "Invalid Book Category. It must only contain alphabets." }, 400);
            var actual = booksService.UpdateData(1, book);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Updating_Book_Details_With_Invalid_Author()
        {
            Book book = new Book { Id = 1, Name = "Sherlock Holmes", Category = "Mystery and Adventure", Author = "Arthur C$^&622onan Doyle", Price = 500 };
            var expected = new Response(null, new List<string> { "Invalid Author Name. It must only contain alphabets." }, 400);
            var actual = booksService.UpdateData(1, book);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Updating_Book_Details_With_Negative_Price()
        {
            Book book = new Book { Id = 1, Name = "Sherlock Holmes", Category = "Mystery and Adventure", Author = "Arthur Conan Doyle", Price = -500 };
            var expected = new Response(null, new List<string> { "Invalid Book Price. It must be a positive value." }, 400);
            var actual = booksService.UpdateData(1, book);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Deleting_Book_With_Negative_Id()
        {
            var expected = new Response(null, new List<string> { "Invalid Id, Id must be a positive number." }, 400);
            var actual = booksService.DeleteBook(-2);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Check_For_Deleting_Book_With_Invalid_Id()
        {
            var expected = new Response(null, new List<string> { "Invalid Id, The Book Id you entered does not exist." }, 400);
            var actual = booksService.DeleteBook(5);
            expected.Should().BeEquivalentTo(actual);
        }

    [Fact]
    public void Check_For_Deleting_Book()
    {
        var expected = new Response(null, new List<string> { "Book Deleted successfully." }, 200);
            var actual = booksService.DeleteBook(2);
            expected.Should().BeEquivalentTo(actual);
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
    }
}
