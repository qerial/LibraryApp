using Library.Core.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
namespace Library.LINQ
{
    public class LINQSorting
    {
        public List<BookDomain> FindBooksByYear(
            List<BookDomain> books, int year)
        {
            return books
                .Where(x => x.PublishedYear == year)
                .ToList();
        }
        public List<BookDomain> FindBooksTitle(
           List<BookDomain> books, string pealkiri)
        {
            return books
                .Where(x => x.Title == pealkiri)
                .ToList();
        }
        public List<BookDomain> UnavaliableBooks(
   List<BookDomain> books)
        {
            return books
                .Where(x => x.IsAvailable == false)
                .ToList();
        }
        public List<LoanDomain> ReaderLoans(
   List<LoanDomain> loans, Guid ReaderId)
        {
            return loans
                .Where(x => x.ReaderId == ReaderId)
                .ToList();
        }
    }
}
