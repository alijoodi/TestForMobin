using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.BookDtos;
using ViewModels;

namespace Interfaces.ServicesInterfaces
{
    public interface IBookService
    {
        Task<PagedListResponse<BookListResponse>> GetBookList(PagedListRequest<BookListRequest> bookListRequest);
        Task<BookAddResponse> AddBook(BookAddRequest bookAddRequest);
    }
}
