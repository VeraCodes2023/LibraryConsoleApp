using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using UserManagement;

namespace BookManagement;

public class BookLoan
{
    public Book? Book { get; set; } 
    public User Borrower { get; set; }
    public DateTime LoanDate { get; set; }   
    public DateTime DueDate { get; set; } 
    public BookLoan(Book book, User borrower)
    {
        Book = book;
        Borrower = borrower;
    }
}
 

