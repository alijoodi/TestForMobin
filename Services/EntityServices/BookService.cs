using AutoMapper;
using Interfaces.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;
using Models.Classes;
using Repositories.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.BookDtos;
using ViewModels.UserDtos;

namespace Services.EntityServices
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            this._authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<BookAddResponse> AddBook(BookAddRequest bookAddRequest)
        {
            var book = _mapper.Map<Book>(bookAddRequest);
            var author = await _authorRepository.FindAsync(x => x.Name == bookAddRequest.AuthorName && x.Family == bookAddRequest.AuthorFamily);

            if (author == null)
            {
                author = new Author { Name = bookAddRequest.AuthorName, Family = bookAddRequest.AuthorFamily };
                await _authorRepository.AddAsync(author);
                await _authorRepository.SaveAllAsync();
            }

            book.Author = author;

            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveAllAsync();

            return _mapper.Map<BookAddResponse>(bookAddRequest);
        }

        public async Task<PagedListResponse<BookListResponse>> GetBookList(PagedListRequest<BookListRequest> bookListRequest)
        {
            var res = await _bookRepository
                .ToTaskPaged(
                x => EF.Functions.Like(x.ISBN, bookListRequest.entityFilter.ISBN)
                || EF.Functions.Like(x.Title, bookListRequest.entityFilter.Title)
                || EF.Functions.Like(x.Publisher, bookListRequest.entityFilter.Publisher)
                || EF.Functions.Like(x.Author.Name, bookListRequest.entityFilter.AuthorName)
                , bookListRequest.pageNumber, bookListRequest.pageSize);
            return new PagedListResponse<BookListResponse> { list = _mapper.Map<List<BookListResponse>>(res), pageNumber = bookListRequest.pageNumber, pageSize = bookListRequest.pageSize };
        }
    }
}
