using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsBorrowed { get; private set; }

    public void Borrow()
    {
        if (IsBorrowed) throw new InvalidOperationException("Book already borrowed.");
        IsBorrowed = true;
    }

    public void Return()
    {
        if (!IsBorrowed) throw new InvalidOperationException("Book was not borrowed.");
        IsBorrowed = false;
    }

    public override string ToString()
    {
        return $"{Title} by {Author} - {(IsBorrowed ? "Borrowed" : "Available")}";
    }
}

class Program
{
    static List<Book> library = new List<Book>();

    static void Main()
    {
        Console.WriteLine("📚 Welcome to Mini Library System\n");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View Books");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Search Book");
            Console.WriteLine("6. Area of Triangle (Exercise)");
            Console.WriteLine("0. Exit");

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddBook(); break;
                case "2": ViewBooks(); break;
                case "3": BorrowBook(); break;
                case "4": ReturnBook(); break;
                case "5": SearchBook(); break;
                case "6": TriangleArea(); break;
                case "0": return;
                default: Console.WriteLine("Invalid option!"); break;
            }
        }
    }

    static void AddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();

        if (string.IsNullOrEmpty(title))
        {
            Console.WriteLine("Title can't be empty!");
            return;
        }

        Console.Write("Enter author name: ");
        string author = Console.ReadLine();

        library.Add(new Book { Title = title, Author = author });
        Console.WriteLine("Book added successfully.");
    }

    static void ViewBooks()
    {
        if (library.Count == 0)
        {
            Console.WriteLine("No books in library.");
            return;
        }

        Console.WriteLine("\nLibrary Contents:");
        foreach (var book in library)
        {
            Console.WriteLine(book);
        }
    }

    static void BorrowBook()
    {
        Console.Write("Enter book title to borrow: ");
        string title = Console.ReadLine();

        var book = library.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        try
        {
            book.Borrow();
            Console.WriteLine("Book borrowed!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ReturnBook()
    {
        Console.Write("Enter book title to return: ");
        string title = Console.ReadLine();

        var book = library.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        try
        {
            book.Return();
            Console.WriteLine("Book returned!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void SearchBook()
    {
        Console.Write("Enter keyword to search: ");
        string keyword = Console.ReadLine();

        var results = library.FindAll(b => b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        if (results.Count == 0)
        {
            Console.WriteLine("No matching books found.");
        }
        else
        {
            Console.WriteLine("Search results:");
            foreach (var b in results)
                Console.WriteLine(b);
        }
    }

    static void TriangleArea()
    {
        Console.WriteLine("📐 Triangle Area Calculator");
        Console.Write("Enter base: ");
        if (!double.TryParse(Console.ReadLine(), out double b))
        {
            Console.WriteLine("Invalid input for base.");
            return;
        }

        Console.Write("Enter height: ");
        if (!double.TryParse(Console.ReadLine(), out double h))
        {
            Console.WriteLine("Invalid input for height.");
            return;
        }

        double area = 0.5 * b * h;
        Console.WriteLine($"Area of Triangle = {area:F2}");
    }
}
