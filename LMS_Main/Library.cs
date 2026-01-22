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
        }
        public bool RemoveMember(int memberId)
        {
            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].Id == memberId)
                {
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
            return null;
        }
        


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

