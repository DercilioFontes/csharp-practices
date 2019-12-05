using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using static System.Console;

namespace CodeFirstDatabase
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        [Key] public int Code { get; set; }
    }

    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }

    class Program
    {
        static void Main()
        {
            using (var db = new BookContext())
            {
                Book book1 = new Book { Title = "Beginning Visual C# 2015", Author = "Perkins, Reid, and Hammer" };
                db.Books.Add(book1);

                Book book2 = new Book { Title = "Beginning XML", Author = "Fawcett, Quin, and Ayers" };
                db.Books.Add(book2);

                db.SaveChanges();

                var query = from b in db.Books
                            orderby b.Title
                            select b;

                WriteLine("All books in the database:");

                foreach(var b in query)
                {
                    WriteLine($"{b.Title} by {b.Author}, Code: {b.Code}");
                }

                WriteLine("Press a key to exit...");
                _ = ReadKey();
            }
        }
    }
}
