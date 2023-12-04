using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookActions;

namespace BookManagement;
public class Comic: Book, IBorrowReturn
    
{
    public Artist ComicArtist { get; set; }
    public class Artist
    {
        public string? BioInfo { get; set; }
    }
        
    public Comic
    (string title, string author, string publishYear, Artist artist)
        :base(title,author,publishYear,true,false,BookType.Comic)
    {
        ComicArtist = artist;
    }
    public override void PrintInfo()
    {
        base.PrintInfo();
        System.Console.WriteLine($"Artist Bio Info: {ComicArtist?.BioInfo}");
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
