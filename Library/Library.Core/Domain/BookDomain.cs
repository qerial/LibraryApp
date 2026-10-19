using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Domain
{
    public class BookDomain
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public bool IsAvalible { get; set; }
        ICollection<LoanDomain> Loans { get; set; } = new List<LoanDomain>();
    }
}
