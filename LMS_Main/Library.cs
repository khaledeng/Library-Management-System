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
        List<Book> Books = new List<Book>();
        private List<Member> Members;
        public Library()
        {
            Members = new List<Member>();
        }
        public void AddMember(Member member)
        {
            Members.Add(member);
            Console.WriteLine($"Member '{member.Name}' added successfully.");
        }
        public bool RemoveMember(int memberId)
        {
            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].Id == memberId)
                {
                    //III
                   Console.WriteLine($"Member {Members[i].Name} removed successfully.");
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
                Console.WriteLine("No members in library.");
                return;
            }
            foreach (Member member in Members)
            {
                Console.WriteLine($"ID: {member.Id}, Name: {member.Name}, Borrowed Books: {member.BorrowedBooks.Count}");

            }
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
            Console.WriteLine($"Member have ID {id} Not Found");   
            return null;
        }
        


        public void AddBook(Book book)
        {
            foreach (Book b in Books)
            {
                if (b.ID == book.ID)

                {
                    Console.WriteLine("Book already exists.");
                    return ;                 
                }
            }
            Books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added successfuly.");
        }
        public void RemoveBooK(int id)
        {
            foreach (Book b in Books)
            {
                if (b.ID == id)
                {
                    Books.Remove(b);

                    Console.WriteLine("Book removed successfully.");
                    return;
                }
            }

            Console.WriteLine("You are trying to delete a book that does not exist.");
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
                Console.WriteLine("Book or Member not found.");
                return;
            }

            if (!book.Availability)
            {
                Console.WriteLine("Book is not available.");
                return;
            }

            member.BorrowBook(book);
            Console.WriteLine($"{member.Name} borrowed '{book.Title}'.");
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
                Console.WriteLine("Member not found.");
                return;
            }

            if (member.ReturnBook(BookId))
            {
                Console.WriteLine($"{member.Name} returned '{book.Title}'.");
                return;
            }

            Console.WriteLine("Book not found in borrowed list.");
        }

        public void ListBooks()
        {
            Console.WriteLine("Books in Library:");
            foreach (Book book in Books)
            {
                Console.WriteLine(book);
            }
        }
    }

}

