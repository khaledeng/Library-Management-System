using project;

namespace LMS_Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool start = true;
            int choice;

            while(start)
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

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Book ID: ");
                        int bookId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        library.AddBook(new Book(bookId, title, author));
                        break;

                    case 2:
                        Console.Write("Enter Book ID: ");
                        library.RemoveBooK(int.Parse(Console.ReadLine()));
                        break;

                    case 3:
                        Console.Write("Enter Member ID: ");
                        int memberId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        library.AddMember(new Member(memberId, name));
                        break;

                    //case 4,5,6,7,8

                    case 9:
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
