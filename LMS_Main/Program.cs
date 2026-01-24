using project;
using System.Net;

namespace LMS_Main
{
    internal class Program
    {
        static ConsoleColor inputColor = ConsoleColor.Yellow;
        static ConsoleColor outputColor = ConsoleColor.Cyan;

        private static void PrintColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static string ReadColored(string prompt, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(prompt);
            Console.ResetColor();
            return Console.ReadLine();
        }

        private static int ReadIntColored(string prompt, ConsoleColor color)
        {
            int value;
            while (true)
            {
                Console.ForegroundColor = color;
                Console.Write(prompt);
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out value))
                    break;
                else
                    PrintColored("Invalid input. Please enter numbers only.", ConsoleColor.Red);
            }
            return value;
        }

        private static string ReadNotEmptyColored(string prompt, ConsoleColor color)
        {
            string input = ReadColored(prompt, color);
            while (string.IsNullOrEmpty(input))
            {
                PrintColored("Cannot be empty.", ConsoleColor.Red);
                input = ReadColored(prompt, color);
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
                PrintColored("Library Management System", outputColor);
                PrintColored("1. Add Book", outputColor);
                PrintColored("2. Remove Book", outputColor);
                PrintColored("3. Add Member", outputColor);
                PrintColored("4. Remove Member", outputColor);
                PrintColored("5. Borrow Book", outputColor);
                PrintColored("6. Return Book", outputColor);
                PrintColored("7. List Books", outputColor);
                PrintColored("8. List Members", outputColor);
                PrintColored("9. Exit", outputColor);

                choice = ReadColored("Select an option: ", inputColor);

                switch (choice)
                {
                    case "1":
                        BookID = ReadIntColored("Enter Book ID: ", inputColor);
                        string title = ReadNotEmptyColored("Enter Title: ", inputColor);
                        string author = ReadNotEmptyColored("Enter Author: ", inputColor);
                        library.AddBook(new Book(BookID, title, author));
                        break;

                    case "2":
                        BookID = ReadIntColored("Enter Book ID: ", inputColor);
                        library.RemoveBooK(BookID);
                        break;

                    case "3":
                        MemberId = ReadIntColored("Enter Member ID: ", inputColor);
                        string name = ReadNotEmptyColored("Enter Name: ", inputColor);
                        library.AddMember(new Member(MemberId, name));
                        break;

                    case "4":
                        MemberId = ReadIntColored("Enter Member ID: ", inputColor);
                        if (library.FindMember(MemberId) != null)
                        {
                            library.RemoveMember(MemberId);
                        }
                        break;

                    case "5":
                        BookID = ReadIntColored("Enter Book ID: ", inputColor);
                        MemberId = ReadIntColored("Enter Member ID: ", inputColor);
                        library.BorrowBook(BookID, MemberId);
                        break;

                    case "6":
                        BookID = ReadIntColored("Enter Book ID: ", inputColor);
                        MemberId = ReadIntColored("Enter Member ID: ", inputColor);
                        library.ReturnBook(BookID, MemberId);
                        break;

                    case "7":
                        library.ListBooks();
                        break;

                    case "8":
                        library.MemberList();
                        break;

                    case "9":
                        start = false;
                        break;

                    default:
                        PrintColored("Invalid option. Try again.\n", ConsoleColor.Red);
                        break;
                }
            }
        }
    }
}
