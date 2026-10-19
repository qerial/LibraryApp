using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Library.Core.Domain
{
    public class Loan
    {
        public Guid Id { get; set; }
        public Book Book { get; set; }
        public Reader Reader { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
