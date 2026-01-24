using project;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace LMS_Main
{

    internal class Library
    {
        #region coloring
        private void PrintColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        } 
        #endregion



        List<Book> Books = new List<Book>();
        private List<Member> Members;

        private const int MaxBooksPerMember = 3;

        public Library()
        {
            Members = new List<Member>();
        }
        public void AddMember(Member member)
        {
            foreach (Member m in Members)
            {
                if (m.Id == member.Id)
                {
                    PrintColored("ID must be unique.\n", ConsoleColor.Red);
                    return;
                }
            }

            Members.Add(member);
            PrintColored($"Member '{member.Name}' added successfully.\n", ConsoleColor.Green);
        }
        public bool RemoveMember(int memberId)
        {
            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].Id == memberId)
                {
                    if (Members[i].BorrowedBooks.Count != 0)
                    {
                        PrintColored("A member with borrowed books cannot be deleted\n", ConsoleColor.Red);
                        return false;
                    }

                    PrintColored($"Member '{Members[i].Name}' removed successfully.\n", ConsoleColor.Green);
                    Members.RemoveAt(i);
                    return true;
                }
            }
    
            return false;
        }

        public void MemberList()
        {
            if (Members.Count == 0)
            {
                PrintColored("No members in library.\n", ConsoleColor.Red);
                return;
            }
            foreach (Member member in Members)
            {
                PrintColored($"ID: {member.Id}, Name: {member.Name}, Borrowed Books: {member.BorrowedBooks.Count}", ConsoleColor.Magenta);

            }
            Console.WriteLine();
        }
        public Member FindMember(int id)
        {
            foreach (var member in Members)
            {
                if (member.Id == id)
                {
                    return member;
                }
            }
            //III
            PrintColored($"Member with ID {id} not found.\n", ConsoleColor.Red);
            return null;
        }
        


        public void AddBook(Book book)
        {
            foreach (Book b in Books)
            {
                if (b.ID == book.ID)

                {
                    PrintColored("ID must be unique.\n", ConsoleColor.Red);
                    return;                 
                }
            }
            Books.Add(book);
            PrintColored($"Book '{book.Title}' added successfully.\n", ConsoleColor.Green);
        }
        public void RemoveBooK(int id)
        {
            foreach (Book b in Books)
            {
                if (b.ID == id)
                {
                    if (b.Availability == false)
                    {
                        PrintColored("The borrowed book cannot be deleted.\n", ConsoleColor.Red);
                        return;
                    }

                    Books.Remove(b);
                    PrintColored("Book removed successfully.\n", ConsoleColor.Green);
                    return;
                }
            }

            PrintColored("You are trying to delete a book that does not exist.\n", ConsoleColor.Red);
            }

        public void BorrowBook(int BookId,int MemberId)
        {
            Book book =null;
            Member member=null ;

            foreach(Book b in Books)
            {
                if(b.ID == BookId)
                {

                    book=b;
                    break;
                }
            }

            foreach(Member m  in Members)
            {
                if(m.Id == MemberId)
                {
                    member=m; 
                    break;
                }
            }

            if(member == null || book == null)
            {
                PrintColored("Book or Member not found.\n", ConsoleColor.Red);
                return;
            }

            if (member.BorrowedBooks.Count >= MaxBooksPerMember)
            {
                PrintColored("Member has reached the maximum number of borrowed books.\n", ConsoleColor.Yellow);
                return;
            }

            if (!book.Availability)
            {
                PrintColored("Book is not available.\n", ConsoleColor.Red);
                return;
            }

            member.BorrowBook(book);
            PrintColored($"{member.Name} borrowed '{book.Title}'.\n", ConsoleColor.Green);
        }

        public void ReturnBook(int BookId,int MemberId)
        {
            Book book =null;
            Member member = null;

            foreach (Book b in Books)
            {
                if (b.ID == BookId)
                {
                    book = b;
                    break;
                }
            }

            foreach (Member m in Members)
            {
                if (m.Id == MemberId)
                {
                    member = m;
                    break;
                }
            }


            if (member == null)
            {
                PrintColored("Member not found.\n", ConsoleColor.Red);
                return;
            }

            if (member.ReturnBook(BookId))
            {
                PrintColored($"{member.Name} returned '{book.Title}'.\n", ConsoleColor.Green);
                return;
            }

            PrintColored("Book not found in borrowed list.\n", ConsoleColor.Red);
        }

        public void ListBooks()
        {
            PrintColored("Books in Library:", ConsoleColor.Magenta);
            foreach (Book book in Books)
            {
                PrintColored(book.ToString(), ConsoleColor.Magenta);
            }
            Console.WriteLine();
        }
    }

}

