using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.AuthorDtos;

namespace Interfaces.ServicesInterfaces
{
    public interface IAuthorService
    {
        Task<AuthorAddResponse> AddAuthor(AuthorAddRequest authorAddRequest);
        Task<AuthorGetListResponse> GetAuthorList();
    }
}
