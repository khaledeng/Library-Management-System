using project;
using System.Collections.Generic;

namespace LMS_Main
{
    internal class Member
    {
        public int Id;
        public string Name;
        public List<Book> BorrowedBooks;

        public Member(int id, string name)
        {
            Id = id;
            Name = name;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            BorrowedBooks.Add(book);
        }

        public bool ReturnBook(int bookId)
        {
            for (int i = 0; i < BorrowedBooks.Count; i++)
            {
                if (BorrowedBooks[i].ID == bookId)
                {
                    BorrowedBooks.RemoveAt(i);//
                    return true;
                }
            }
            return false;
        }
    }
}
