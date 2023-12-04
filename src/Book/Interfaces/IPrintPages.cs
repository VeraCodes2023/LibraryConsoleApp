using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookActions;
public interface IPrintPages
{
    
    public void PrintPages(int startPage,int endPage, int maxAllowPages);
    
}
