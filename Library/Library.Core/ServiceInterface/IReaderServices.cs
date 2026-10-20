using Library.Core.Domain;
using Library.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.ServiceInterface
{
    public interface IReaderServices
    {
        Task<ReaderDomain> Create(ReaderDto dto);

    }
}
