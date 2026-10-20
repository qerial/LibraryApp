using Library.Core.Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Library.LINQ
{
    public class LINQSorting
    {
        public List<BookDomain> FindBooksByYear
            (List<BookDomain> books, string year)
        {
            return books
                .Where(x => x.PublishedYear.ToString().Contains(year))
                .ToList();
        }

        public List<BookDomain> FindBooksTitle
            (List<BookDomain> books, string pealkiri)
        {
            return books
                .Where(x => x.Title.ToLower().Contains(pealkiri.ToLower()))
                .ToList();
        }

        public List<BookDomain> UnavaliableBooks
            (List<BookDomain> books)
        {
            return books
                .Where(x => !x.IsAvailable)
                .ToList();
        }

        public List<LoanDomain> ReaderLoans
            (List<LoanDomain> loans, Guid readerId)
        {
            return loans
                .Where(x => x.ReaderId == readerId)
                .ToList();
        }
    }
}