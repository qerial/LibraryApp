using Library.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Dto
{
    public class LoanDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid ReaderId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
