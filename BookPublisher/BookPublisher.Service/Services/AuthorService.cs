using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;

namespace BookPublisher.Service.Services
{
    public sealed class AuthorService : BaseService<AuthorModel>, IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBookAuthorRepository _bookAuthorRepository;

        public AuthorService(IAuthorRepository authorRepository, IBookRepository bookRepository, IBookAuthorRepository bookAuthorRepository) : base(authorRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<IEnumerable<AuthorModel>> ListAuthorsWithBookAsync()
        {
            var listAuthors = await _authorRepository.ListAsync();

            foreach(var author in listAuthors)
            {
                var authorBook = _bookAuthorRepository.GetOneByCriteria(x => (x.AuthorId == author.Id));
                if(authorBook != null)
                {
                    var bookModel = await _bookRepository.GetAsync(authorBook.BookId);
                    author.BookAuthor.Add(authorBook);

                    foreach(var Book in author.BookAuthor)
                    {
                        Book.Book = bookModel;
                    }
                }
            }

            return listAuthors;
        }

        public async Task<AuthorModel> GetAuthorWithBooksAsync(int id)
        {
            var author = await _authorRepository.GetAsync(id);

            var authorBook = _bookAuthorRepository.GetOneByCriteria(x => (x.AuthorId == author.Id));
            if (authorBook != null)
            {
                var bookModel = await _bookRepository.GetAsync(authorBook.BookId);
                author.BookAuthor.Add(authorBook);
                author.BookAuthor.Remove(authorBook);
            }

            return author;
        }
    }
}
