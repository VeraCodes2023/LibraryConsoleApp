using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookActions;
namespace BookManagement;

public class ResearchPaper: Book,IPrintPages
{
    public ResearchPaper
     (string title, string author, string publishYear)
        :base(title,author,publishYear,false,true,BookType.ResearchPaper)
    {
        
    }
}
