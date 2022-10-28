using BookPublisher.Domain.DTOs;
using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;

namespace BookPublisher.Service.Services
{
    public sealed class BookService : BaseService<BookModel>, IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IAuthorRepository _authorRepository;
        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository) : base(bookRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<BookModel> InsertBookWithAuthorAsync(NewBookDTO dto)
        {
            var book = BookModel.Create(dto);

            foreach (var id in dto.Authors)
            {
                var bookAuthor = new BookAuthorModel()
                {
                    Author = await _authorRepository.GetAsync(id),
                    Book = book
                };

                book.BookAuthor.Add(bookAuthor);
            }

            await _bookRepository.InsertAsync(book);

            return book;
        }
    }
}
