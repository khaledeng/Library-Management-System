<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LMS_Main
{
    internal class Library
    {
    }
}
﻿using project;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace LMS_Main
{
    internal class Library
    {
        List<Book> Books = new List<Book>();



        public void AddBood(Book book)
        {
            foreach (Book b in Books)
            {
                if (b.ID == book.ID)

                {
                        Console.WriteLine("Book already exists.");
                   
                }
                else
                {
                    Books.Add(book);
                    Console.WriteLine("Book added successfuly.");
                }
            }
        }
        public void RemoveBooK(int id)
        {
            foreach (Book b in Books)
            {
                if (b.ID == id)
                {
                    Books.Remove(b);

                    Console.WriteLine("Book removed successfully.");
                }
            }
        }

        
    }

}

>>>>>>> 7e12835 (Update Book and add Library class)
