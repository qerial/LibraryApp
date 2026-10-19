using System;

namespace Library.Core.Domain
{
    public class LoanDomain
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public BookDomain Book { get; set; } = null!;
        public Guid ReaderId { get; set; }
        public ReaderDomain Reader { get; set; } = null!;
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
