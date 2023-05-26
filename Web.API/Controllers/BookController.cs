using API.Controllers;
using Interfaces.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using ViewModels.BookDtos;
using ViewModels.UserDtos;

namespace Web.API.Controllers
{
    public class BookController : BaseApiController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        //[Authorize(Roles ="admin")]
        [HttpPost("api/Book/GetBookList")]
        public async Task<ActionResult<PagedListResponse<BookListResponse>>> GetBookList(PagedListRequest<BookListRequest> bookListRequest)
        {
            return await _bookService.GetBookList(bookListRequest);
        }

        [AllowAnonymous]
        //[Authorize(Roles = "admin")]
        [HttpPost("api/Book/AddBook")]
        public async Task<ActionResult<BookAddResponse>> AddBook(BookAddRequest bookAddRequest)
        {
            return await _bookService.AddBook(bookAddRequest);
        }

    }
}
