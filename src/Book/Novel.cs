using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookActions;

namespace BookManagement;
public class Novel: Book, IBorrowReturn
{
    public Genre Novelgenre { get; set; }
    public enum Genre
    {
        Mystery,
        ScienceFiction,
        Fantasy,
        Romance,
        Horror,
        Absurdist
    }
    public Novel
    (string title, string author,string publishYear,Genre genre)
    : base(title,author,publishYear,true,false, BookType.Novel)
    {
         Novelgenre = genre;
    }
    public override void PrintInfo()
    {
        base.PrintInfo();
        System.Console.WriteLine($"Genre: {Novelgenre}");
    }
      public void BorrowBook(string ISBN)
    {
        try
        {
            Console.WriteLine($"Book ISBN {ISBN} is lent.");
        }
        catch(Exception e)
        {
            throw new NotImplementedException(e.Message);
        }

    }
    public void ReturnBook(string ISBN)
    {
         try
        {
            Console.WriteLine($"Book ISBN {ISBN} is returned.");
        }
        catch(Exception e)
        {
            throw new NotImplementedException(e.Message);
        }
    }
}
