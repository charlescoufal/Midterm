using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace One
{
    public class Book
    {
        public int BookID {get; set;}
        public string Title {get; set;}
        public string Publisher {get; set;}
        public DateTime PublishedDate {get; set;}
        public int PageNumber {get; set;}
        public ICollection<Author> Authors { get; set; }
        public Author AuthorID {get; set;}
        public Author FirstName {get; set;}
        public Author LastName {get; set;}


        

        public override string ToString()
        {
            return $"{BookID}-{Title}";
        }

    }
}