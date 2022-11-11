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
        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IBookAuthorRepository bookAuthorRepository) : base(bookRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<BookModel> InsertBookWithAuthorAsync(NewBookDTO dto)
        {
            var book = BookModel.Create(dto);

            foreach (var id in dto.AuthorsId)
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

        public async Task<IEnumerable<BookModel>> ListBooksWithAuthorsAsync()
        {
            var listBooks = await _bookRepository.ListAsync();

            foreach (var book in listBooks)
            {
                var bookAuthor = _bookAuthorRepository.GetOneByCriteria(x => (x.BookId == book.Id));
                var authorModel = await _authorRepository.GetAsync(bookAuthor.AuthorId);
                book.BookAuthor.Add(bookAuthor);

                foreach(var Author in book.BookAuthor)
                {
                    Author.Author = authorModel;
                }
            }

            return listBooks;
        }

        public async Task<BookModel> GetBookWithAuthorsAsync(int id)
        {
            var book = await _bookRepository.GetAsync(id);

            var bookAuthor = _bookAuthorRepository.GetOneByCriteria(x => (x.BookId == book.Id));
            var authorModel = await _authorRepository.GetAsync(bookAuthor.AuthorId);
            book.BookAuthor.Add(bookAuthor);
            book.BookAuthor.Remove(bookAuthor);

            return book;
        }
    }
}
