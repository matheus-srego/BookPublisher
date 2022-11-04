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
    public sealed class BookAuthorService : BaseService<BookAuthorModel>, IBookAuthorService
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;
        public BookAuthorService(IBookAuthorRepository bookAuthorRepository) : base(bookAuthorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
        }
    }
}
