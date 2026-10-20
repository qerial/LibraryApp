using Library.Core.Domain;

namespace Library.Models.Loan
{
    public class LoanCreateViewModel
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid ReaderId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
