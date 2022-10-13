using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Service.Services
{
    public sealed class AuthorService : BaseService<AuthorModel>, IAuthorService
    {
        public AuthorService(IBaseRepository<AuthorModel> baseRepository) : base(baseRepository)
        {
            // ---
        }
    }
}
