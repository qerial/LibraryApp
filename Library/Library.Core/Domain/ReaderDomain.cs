using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Domain
{
    public class ReaderDomain
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        ICollection<LoanDomain> Loans { get; set; } = new List<LoanDomain>();
    }
}
