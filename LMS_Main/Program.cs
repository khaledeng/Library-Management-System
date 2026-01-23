using project;
using System.Net;

namespace LMS_Main
{
    internal class Program
    {
        static int intOnly()
        {
            int Book_Member_id = 0;
            while (!int.TryParse(Console.ReadLine(), out Book_Member_id))
            {
                Console.WriteLine("Invalid input Please enter numbers only.");
                Console.Write("Enter ID: ");
            }
            return Book_Member_id;
        }

        static string NotEmptyString()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Cant Be Null Here");
                Console.Write("Enter The Field: ");
                input = Console.ReadLine();
            }

            return input;
        }
        static void Main(string[] args)
        {

            Library library = new Library();
            bool start = true;
            string choice;
            int BookID = 0;
            int MemberId = 0;


            while (start)
            {
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Add Member");
                Console.WriteLine("4. Remove Member");
                Console.WriteLine("5. Borrow Book");
                Console.WriteLine("6. Return Book");
                Console.WriteLine("7. List Books");
                Console.WriteLine("8. List Members");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Book ID: ");
                        BookID = intOnly();
                        Console.Write("Enter Title: ");
                        string title = NotEmptyString();
                        Console.Write("Enter Author: ");
                        string author = NotEmptyString();
                        library.AddBook(new Book(BookID, title, author));
                        break;

                    case "2":
                        Console.Write("Enter Book ID: ");
                        BookID = intOnly();
                        library.RemoveBooK(BookID);
                        break;

                    case "3":
                        Console.Write("Enter Member ID: ");
                        MemberId = intOnly();
                        Console.Write("Enter Name: ");
                        string name = NotEmptyString();
                        library.AddMember(new Member(MemberId, name));
                        break;

                    //case 4,5,6,7,8
                    case "4":
                        {
                            Console.Write("Enter Member ID: ");
                            MemberId = intOnly();
                            if (library.FindMember(MemberId) != null)
                            {
                                library.RemoveMember(MemberId);
                                break;
                            }

                            break;
                        }
                    case "5":
                        {
                            //if not found is trurn  actoin=> '' borrowed ''
                            Console.Write("Enter Book ID:");
                            BookID = intOnly();
                            Console.Write("Enter MemberId ID:");
                            MemberId = intOnly();

                            library.BorrowBook(BookID, MemberId);
                            break;

                        }
                    case "6":
                        {
                            Console.Write("Enter Book ID:");
                            BookID = intOnly();

                            Console.Write("Enter MemberId ID:");
                            MemberId = intOnly();

                            library.ReturnBook(BookID, MemberId);
                            break;
                        }
                    case "7":
                        {
                            library.ListBooks();
                            break;
                        }
                    case "8":
                        {
                            library.MemberList();
                            break;
                        }

                    case "9":
                        start = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
