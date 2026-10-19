using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Library.Core.Domain
{
    public class LoanDomain
    {
        public Guid Id { get; set; }
        public BookDomain Book { get; set; }
        public ReaderDomain Reader { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
