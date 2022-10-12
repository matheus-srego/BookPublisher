using BookPublisher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Domain.Interfaces.Services
{
    internal interface IBaseService<T> where T : BaseEntity
    {
        Task<T> Insert(T entity, CancellationToken cancellationToken = default);
    }
}
