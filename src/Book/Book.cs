using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BookManagement;
public  class Book
{
    public string?  ISBN {get; set;}
    public string? Title {get; set;}
    public string? Author {get;set;}
    public BookType Type { get; set; }
    public string? PublishYear {get;set;}
    public bool CanBorrow {get;set;}
    public bool CanPrint {get;set;}
    public Book(){}

    public  Book
    (string title, string author, string PublishYear,bool CanBorrow,bool CanPrint, BookType type)
    {
       this.ISBN = GenerateISBN();
        this.Title = title;
        this.Author = author;
        this.Type = type;
        this.PublishYear = PublishYear;
        this.CanBorrow = CanBorrow;
        this.CanPrint = CanPrint;
    }
    public override string ToString()
    {
        return $"ISBN: {ISBN}, Title: {Title}, Author: {Author}, Published year: {PublishYear}, Can Borrow: {Borrowable(CanBorrow)}, Can Print: {Printable(CanPrint)}, BookType: {Type}"; 
    }
    public virtual void  PrintInfo()
    {
        var content = ToString();
        Console.WriteLine(content);
    }
    public void UpdateBook(BookUpdateDTO bookUpdateDTO)
    {
        Title = bookUpdateDTO.Title;
        Author = bookUpdateDTO.Author;
        PublishYear = bookUpdateDTO.PublishYear;
    }
   
    private string Borrowable(bool CanBorrow)
    {
        return CanBorrow? "Yes":"No";
    }

    private string Printable(bool CanPrint)
    {
        return CanPrint? "Yes":"No";
    }
    public string GenerateISBN()
    {
        DateTime now = DateTime.Now;
        string isbn=now.ToString("yyMMddHHmmssfff");
        isbn += new Random().Next(1000,9999);
        return isbn;
    }
    public void PrintPages(int startPage, int endPage, int maxAllowPages)
    {
        try{

            if(startPage < 1 || endPage <startPage || endPage > maxAllowPages )
            {
            System.Console.WriteLine("Invalid page range. Please provide valid page numbers.");
            }
            else
            {
            System.Console.WriteLine($"Printing  {startPage} to {endPage}.");
            }
        }
        catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }

}

 
