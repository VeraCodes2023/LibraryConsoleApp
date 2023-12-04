using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookActions;
public interface IBorrowReturn
{
    public void BorrowBook(string ISBN);
    public void ReturnBook(string ISBN);
}
