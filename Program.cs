using System;
using System.Linq;
using System.Collections.Generic;

namespace One
{
    class Program
    {
        static void Main(string[] args)
        {



            SeedDatabase();
            
            LINQWhere1();
            
            LINQWhere2();
            
            LINQWhere3();

            LINQFind1();

            LINQFind2();

        }

        public static void SeedDatabase()
        {
            using(var db = new AppDbContext())
            {
                try
                {
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    if(!db.Authors.Any() && !db.Books.Any())
                    {
                        IList<Author> authorList = new List<Author>()
                        {
                            new Author() { AuthorID = 1, FirstName = "Adam", LastName = "Freeman"},
                            new Author() { AuthorID = 2, FirstName = "Haishi", LastName = "Bai"}
                        };


                        db.Authors.AddRange(authorList);


                        IList<Book> bookList = new List<Book>() { 
                            new Book() { BookID = 1, Title = "Pro ASP.NET Core MVC 2 7th ed. Edition", Publisher = "Apress", PublishedDate = DateTime.Parse("2017-10-25"), PageNumber = 1017, AuthorID = 1},
                            new Book() { BookID = 2, Title = "Pro Angular 6 3rd Edition", Publisher = "Apress", PublishedDate = DateTime.Parse("2018-10-10"), PageNumber = 776, AuthorID = 1},
                            new Book() { BookID = 3, Title = "Programming Microsoft Azure Service Fabric (Developer Reference) 2nd Edition", Publisher = "Microsoft Press", PublishedDate = DateTime.Parse("2018-05-25"), PageNumber = 528, AuthorID = 2},
                        };  

                        db.Books.AddRange(bookList);

                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Try again.");
                    }
                }
                catch(Exception exp)
                {
                    Console.Error.WriteLine(exp.Message);
                }
            }
        }       

        public static void LINQWhere1()
        {
            using(var db = new AppDbContext())
            {
                var v = from s in db.Books
                                    select s;

                PrintList(v);
            }
        } 

        public static void LINQWhere2()
        {
            using(var db = new AppDbContext())
            {
                var v = from s in db.Books
                                    where s.Publisher == "Apress"
                                    select s.Title;

                PrintList(v);
            }
        } 

        public static void LINQWhere3()
        {
            using(var db = new AppDbContext())
            {
                var v = from t in db.Books 
                                        orderby t.AuthorID
                                        select t;

                PrintList(v);
            }
        }

        public static void LINQFind1(){
            using(var db = new AppDbContext())
            {
                var v = db.Books.Where(s => s.FirstName == "Adam").FirstOrDefault();

                PrintList(v);
            }
        }

        public static void LINQFind2(){
            using(var db = new AppDbContext())
            {
                var filteredResult = db.Books.Where(t => t.PageNumber >= 1000);

                Console.WriteLine(filteredResult);
            }
        }

        
        

        public static void PrintList(IEnumerable<Object> list)
        {
            foreach(var s in list)
            {
                Console.WriteLine(s);
            }
        }
    }
}
