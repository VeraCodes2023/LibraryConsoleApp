using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.Reflection.Metadata;
using System.Data.Common;

using BookManagement;
using UserManagement;
using System.Reflection;

namespace LibraryApp;
public class Library
{
    public string?  ISBN;
    private Dictionary<string, Book> _books = new Dictionary<string, Book>();
    private Dictionary<string, User> _users = new Dictionary<string, User>();
    private List<BookLoan> _loanedBooks = new List<BookLoan>();
 
    public Library()
    {
       LoadData();
    }

    // loading hybrid deserialized data from json files 
    private void LoadData()
    {
        if (File.Exists("books.json"))
        {
            string bookJson = File.ReadAllText("books.json");
            var deserializedBooks = JsonSerializer.Deserialize<Dictionary<string, Book>>(bookJson);
            if(deserializedBooks is not null)
            {
                _books = deserializedBooks;
            }
            else
            {
                Console.WriteLine("Deserialization failed: Data is null");
            }
        }

        if (File.Exists("users.json"))
        {
            string userJson = File.ReadAllText("users.json");
            var deserializedUsers = JsonSerializer.Deserialize<Dictionary<string,User>>(userJson);
            if(deserializedUsers is not null)
            {
                _users= deserializedUsers;
            }
            else
            {
                Console.WriteLine("Deserialization failed: Data is null");
            }
        }
    }

// ****************Book Section Starts 
    public Dictionary<string,Book>GetBooks
    {
        get
        {
           return new Dictionary<string, Book>(_books);
        }
    }
    private string GenerateISBN()
    {
        DateTime now = DateTime.Now;
        string isbn=now.ToString("yyMMddHHmmssfff");
        isbn += new Random().Next(1000,9999);
        return isbn;
    }
    public void PrintPages (string isbn, int startPage, int endPage, int maxAllowPages)
    {
        try
        {
            if ( _books.ContainsKey(isbn))
            {
                Book book = _books[isbn];
                if (book.Type == BookType.ResearchPaper || book.Type ==BookType.TextBook)
                {
                    book.PrintPages(startPage,endPage,maxAllowPages);
                }
                else
                {
                    Console.WriteLine($"Book with ISBN {isbn} is not printable.");
                }  
            }
            else
            {
                Console.WriteLine($"Book with ISBN {isbn} not found in the library.");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void PrintBookInfo (Book book)
    {
      book.PrintInfo();
    }
    public void AddBook(Book book)
    {
        try{
              if(book.ISBN is not null)
              if(_books.ContainsKey(book.ISBN))
              {
                System.Console.WriteLine("Book already existed in the Library");
              }
              else
              {
                string generatedISBN = GenerateISBN();
                book.ISBN = generatedISBN; 
                _books.Add(generatedISBN, book);
                SaveBooksToJsonFile();
              }
        }
        catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
   
    }
    public void RemoveBook(string isbn)
    {
        try
        {
            if(_books.ContainsKey(isbn))
            {
                _books.Remove(isbn);
                SaveBooksToJsonFile();
                Console.WriteLine($"Book with ISBN:{isbn} has been deleted.");
            }
            else
            {
                Console.WriteLine($"Book with ISBN {isbn} not found in the library.");
            }
        }catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
       
    }
    public void UpdateBook (string isbn, BookUpdateDTO update)
    {
        try
        {
            if(_books.ContainsKey(isbn) && update !=null)
            {
                Book bookToUpdate = _books[isbn];
                if(update.Title !=null)
                {
                    bookToUpdate.Title = update.Title;
                }
                if (update.Author != null)
                {
                    bookToUpdate.Author = update.Author;
                }
                if (update.PublishYear != null)
                {
                    bookToUpdate.PublishYear = update.PublishYear;
                }
                SaveBooksToJsonFile();
                Console.WriteLine($"Book with ISBN: {isbn} has been updated.");
            }
        else
        {
            Console.WriteLine($"Book with ISBN: {isbn} not found in the library.");
        }
    }
    catch
    (Exception e)
    {
        Console.WriteLine(e.Message);
    }
       
    }
    public void FindBook (string isbn)
    {
        try
        {
            if(_books.ContainsKey(isbn)){
                Console.WriteLine($"Book ISBN : {isbn}  is available.");
            }
            else
            {
                Console.WriteLine($"Book with ISBN: {isbn} not found in the library.");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
        
    }
    private void SaveBooksToJsonFile()
    {
        string json = JsonSerializer.Serialize(_books, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("books.json", json);
    }
//>>>>>>>>>>>>>>>>>>>>>>>>>> Book Section Ends
//************************** User Section Starts

    public Dictionary<string, User>GetUsers
    {
        get 
        {
            return new Dictionary<string, User>(_users);
        }
    }
    public void AddUser(User user)
    {
        try{
             if(user.Id is not null)
             if(_users.ContainsKey(user.Id))
             {
                
                System.Console.WriteLine("User already existed in the Library");
             }
             else
             {
               string generatedISBN = GenerateISBN();
               user.Id = generatedISBN; 
                _users.Add(generatedISBN,user);
                SaveUsersToJsonFile();
             }
        }
        catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
   
    }
    public bool RemoveUser(string isbn)
    {
        try
        {
            if (_users.ContainsKey(isbn))
            {
                _users.Remove(isbn);
                SaveUsersToJsonFile();
                Console.WriteLine($"User with ISBN:{isbn} has been deleted.");
                return true;
            }
            else
            {

                Console.WriteLine($"User with ISBN {isbn} not found.");
                return false;
            }
        }catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
            return false;
        }
       
    }
    public void UpdateUser (string isbn, UserUpdateDTO newUser)
    {
        try
        {
            if(_users.ContainsKey(isbn) && newUser !=null)
            {
                User userToUpdate = _users[isbn];
                if(newUser.Name !=null)
                {
                    userToUpdate.Name = newUser.Name;
                }
                if (newUser.Email != null)
                {
                    userToUpdate.Email = newUser.Email;
                }
            
                SaveUsersToJsonFile();
                Console.WriteLine($"User ID: {isbn} has been updated.");
            }
            else
            {
                Console.WriteLine($"User ID: {isbn} not found in the library.");
            }
        }
        catch
        (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
    }
    
    public void FindUserById(string isbn)
    {
        try
        {
             if(_users.ContainsKey(isbn))
             {
                Console.WriteLine($"User with ID: {isbn} found!");
             }
            else
            {
                Console.WriteLine($"User with Id:{isbn} can not found");
            }
        }
        catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
       
    }

    private void SaveUsersToJsonFile()
    {
        string json = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("users.json", json);
    }
//>>>>>>>>>>>>>>>>>>>>>>>>>> User Section Ends

    public void LoanBook (string isbn, User borrower)
    {
        if(_books.ContainsKey(isbn))
        {
            Book bookToLoan = _books[isbn];
            if(bookToLoan.CanBorrow && borrower.Role==RoleType.Customer)
            {
                _books.Remove(isbn);
                _loanedBooks.Add(new BookLoan(bookToLoan,borrower));
                Console.WriteLine($"Book with ISBN: {isbn} has been loaned to {borrower.Name}.");
            }
            else
            {
                Console.WriteLine("Book only can be lent to cusomters.");
            }
        }
        else
        {
            Console.WriteLine("Book already lent.");
        }
    }
    public void CollectBook (string isbn, User librarian)
    {
        if(_books.ContainsKey(isbn))
        {
            Book bookToReturn = _books[isbn];
            if(bookToReturn.CanBorrow &&librarian.Role==RoleType.Librarian)
            {
                if (_loanedBooks.FirstOrDefault(b=>b.Book != null && b.Book.ISBN ==isbn) is not null)
                {
                    BookLoan? loanedBook = _loanedBooks.FirstOrDefault(b=>b.Book != null && b.Book.ISBN ==isbn);
                    if(loanedBook is not null)
                    {
                         _loanedBooks.Remove(loanedBook);
                          _books.Add(isbn,bookToReturn);
                    }
                   
                }
                Console.WriteLine($"Book with ISBN: {isbn} has been collected by libraian {librarian.Name}.");
            }
            else
            {
                Console.WriteLine("Book only can be collected by librarian.");
            }
        }
        else
        {
            Console.WriteLine("Book already returned.");
        }
    }

}
