using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;

using BookManagement;
using UserManagement;
using LibraryApp;

class Program
{
    static void Main ()
    {
        try
        {
            Library lib = new Library();
            // lib.AddBook(new TextBook("Suomen Mestari2", "Finn Lecture", "2000"));
            // lib.AddBook(new Novel("Pride and Prejudice", "Jane Austen", "1813", Novel.Genre.Romance));
            // lib.AddBook(new Novel("Waiting for Godot", "Samuel Beckett", "1953", Novel.Genre.Absurdist));
            // lib.AddBook(new ResearchPaper("Anthropology", "Camelot Davis", "2003"));
            // lib.RemoveBook("2311051351209117824");//Book with ISBN:2311051351209117824 has been deleted.
            // lib.UpdateBook("2311051349549836815",new BookUpdateDTO("New Book Title","New Author","1981")); //Book with ISBN: 2311051349549836815 has been updated.
            //lib.AddBook(new Comic("The Walking Dead", "Robert Kirkman", "2003-2019", 
            // new Comic.Artist { BioInfo = "born in 1978, Lexington Kentucky, United States" }));
            lib.PrintBookInfo(new TextBook("Suomen Mestari2", "Finn Lecture", "2000"));
            lib.PrintBookInfo(new Comic("The Walking Dead", "Robert Kirkman", "2003-2019", 
            new Comic.Artist { BioInfo = "born in 1978, Lexington Kentucky, United States" }));
            lib.PrintPages("2311051422546915455",1,20,200);
            lib.PrintPages("2311051432225634444",20,30,55);
            lib.PrintPages("2311042020181747418",10,20,25); // Exception captured
            lib.FindBook("2311051349549836815");
            
            // lib.AddUser(new User("Annie", "annie@mail.com", RoleType.Customer));
            // lib.AddUser(new User("Lydia", "lydia@mail.com", RoleType.Customer));
            // lib.AddUser(new User("Jamie", "jamie@mail.com", RoleType.Customer));
            // lib.AddUser(new User("Joy", "joy@mail.com", RoleType.Customer));
            // lib.AddUser(new User("andy", "andy@mail.com", RoleType.Librarian));
           lib.FindUserById("2311051702297263185");
           lib.LoanBook("2311051349549836815",new User("Sandy","sandy@mail.com",RoleType.Customer));
           lib.CollectBook("2311051349549836815",new User("Sandy","sandy@mail.com",RoleType.Customer));
            
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }

}

