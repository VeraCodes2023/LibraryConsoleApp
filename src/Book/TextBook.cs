using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookActions;

namespace BookManagement;
public class TextBook : Book, IBorrowReturn , IPrintPages
{
    public TextBook(){}
    public TextBook
    (string title, string author, string publishYear)
        :base(title,author,publishYear,false,true,BookType.TextBook)
    {
 
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
