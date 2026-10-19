using System;
using System.Collections.Generic;

namespace Library.Core.Domain
{
    public class BookDomain
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }
        ICollection<LoanDomain> Loans { get; set; } = new List<LoanDomain>();
    }
}
