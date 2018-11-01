using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace One
{
    public class Author
    {
        [ForeignKey("Book")]
        public int AuthorID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}



        

        public override string ToString()
        {
            return $"{AuthorID}-{FirstName} {LastName}";
        }
    }
}