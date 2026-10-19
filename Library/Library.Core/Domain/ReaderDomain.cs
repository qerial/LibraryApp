using System;
using System.Collections.Generic;

namespace Library.Core.Domain
{
    public class ReaderDomain
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        ICollection<LoanDomain> Loans { get; set; } = new List<LoanDomain>();
    }
}
