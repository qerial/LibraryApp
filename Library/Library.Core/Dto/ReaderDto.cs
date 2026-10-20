using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Dto
{
    public class ReaderDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
