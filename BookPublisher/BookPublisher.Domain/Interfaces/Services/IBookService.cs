using BookPublisher.Domain.DTOs;
using BookPublisher.Domain.Models;

namespace BookPublisher.Domain.Interfaces.Services
{
    public interface IBookService : IBaseService<BookModel>
    {
        Task<BookModel> InsertBookWithAuthorAsync(NewBookDTO dto);
    }
}
