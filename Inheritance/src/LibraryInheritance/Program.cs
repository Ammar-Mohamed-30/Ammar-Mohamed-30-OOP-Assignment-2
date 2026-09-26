namespace LibraryInheritance;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== LIBRARY INHERITANCE ===\n");

        var student = new StudentMember(
            "S1",
            "Ali Ahmed",
            "01000000001");

        var premium = new PremiumMember(
            "P1",
            "Omar Hassan",
            "01000000002",
            20m);

        var librarian = new Librarian(
            "L1",
            "Mona Ali",
            "01000000003",
            new DateTime(2025, 1, 1),
            10000m);

        var shelver = new Shelver(
            "S2",
            "Sara Nabil",
            "01000000004",
            new DateTime(2025, 2, 1),
            8000m,
            "Fiction");

        var head = new HeadLibrarian(
            "H1",
            "Khaled Omar",
            "01000000005",
            new DateTime(2024, 1, 1),
            15000m);

        var book = new Book("B1", "C# Basics", 2m);
        var dvd = new DVD("D1", "C# Course DVD", 5m);
        var magazine = new Magazine("M1", "Tech Magazine", 4m);

        Console.WriteLine("=== STAFF PAY ===");

        List<Staff> staff = new List<Staff>
        {
            librarian,
            shelver,
            head
        };

        foreach (Staff member in staff)
        {
            Console.WriteLine($"{member.FullName}: {member.MonthlyPay}");
        }

        Console.WriteLine("\n=== ITEM INFORMATION ===");

        List<LibraryItem> items = new List<LibraryItem>
        {
            book,
            dvd,
            magazine
        };

        foreach (LibraryItem item in items)
        {
            Console.WriteLine(
                $"{item.Title}: {item.LoanPeriodDays} days, daily fee = {item.DailyLateFee}");
        }

        Console.WriteLine("\n=== WITHDRAWN ITEM TEST ===");

        book.Withdraw();

        try
        {
            student.Borrow(book, "L1", new DateTime(2026, 9, 26));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        book.Restore();

        Console.WriteLine("\n=== DOUBLE LOAN TEST ===");

        student.Borrow(book, "L2", new DateTime(2026, 9, 26));

        try
        {
            premium.Borrow(book, "L3", new DateTime(2026, 9, 26));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n=== STUDENT LOAN LIMIT TEST ===");

        var book2 = new Book("B2", "Book 2", 2m);
        var book3 = new Book("B3", "Book 3", 2m);
        var book4 = new Book("B4", "Book 4", 2m);

        student.Borrow(book2, "L4", new DateTime(2026, 9, 26));
        student.Borrow(book3, "L5", new DateTime(2026, 9, 26));

        try
        {
            student.Borrow(book4, "L6", new DateTime(2026, 9, 26));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n=== PREMIUM MEMBER LATE RETURN ===");

        Loan premiumLoan = premium.Borrow(
            dvd,
            "L7",
            new DateTime(2026, 9, 1));

        DateTime returnDate = premiumLoan.DueDate.AddDays(5);

        premiumLoan.Return(returnDate);

        Console.WriteLine($"Due date: {premiumLoan.DueDate:d}");
        Console.WriteLine($"Return date: {premiumLoan.ReturnDate:d}");
        Console.WriteLine($"Late fee: {premiumLoan.LateFee}");
        Console.WriteLine($"Reading points: {premium.ReadingPoints}");

        Console.WriteLine("\n=== INVALID STATUS CHANGES ===");

        try
        {
            premiumLoan.Return(returnDate);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            premiumLoan.MarkAsLost();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("\n=== INVALID RETURN DATE TEST ===");

        var dateTestBook = new Book(
            "B5",
            "Date Test Book",
            2m);

        Loan dateTestLoan = premium.Borrow(
            dateTestBook,
            "L8",
            new DateTime(2026, 9, 20));

        try
        {
            dateTestLoan.Return(
                new DateTime(2026, 9, 19));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("\n=== INVALID LATE FEE TEST ===");

        try
        {
            head.ChangeLateFee(book, 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n=== RAISE TEST ===");

        try
        {
            librarian.GiveRaise(0);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        librarian.GiveRaise(10);
        Console.WriteLine($"Librarian new pay: {librarian.MonthlyPay}");

        Console.WriteLine("\n=== SHELVER REASSIGN ===");

        Console.WriteLine($"Old section: {shelver.Section}");
        shelver.Reassign("Children");
        Console.WriteLine($"New section: {shelver.Section}");
        Console.WriteLine("\n=== INVALID IDENTITY TEST ===");

        try
        {
            var invalidStudent = new StudentMember(
                "",
                "",
                "");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n=== MUST NOT COMPILE ===");

        // new Person("P", "Name", "Phone");              // must NOT compile
        // new Member(...);                              // must NOT compile
        // new Staff(...);                               // must NOT compile
        // new LibraryItem(...);                         // must NOT compile
        // student.FullName = "New Name";                // must NOT compile
        // student.Loans.Add(...);                       // must NOT compile
        // book.IsOnLoan = true;                         // must NOT compile
    }
}