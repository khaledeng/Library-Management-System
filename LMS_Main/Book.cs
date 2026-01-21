using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Book
    {
        public int ID;
        public string Title;
        public string Author;
        public bool Availability = true;

        public Book(int iD, string title, string author)
        {
            ID = iD;
            Title = title;
            Author = author;

        }
        public override string ToString()
        {
            return $"Book Id : {ID} Book Title : {Title} Book Author : {Author} Book Availability :{Availability}";

        }

    }
}
