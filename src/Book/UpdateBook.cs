using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement;

public class BookUpdateDTO 
{
    public string Title {get;set;}
    public string Author { get; set; }
    public string PublishYear {get;set;}
    public BookUpdateDTO (string title, string author, string publishYear)
    {
        Title = title;
        Author = author;
        PublishYear = publishYear;
    }
}  
