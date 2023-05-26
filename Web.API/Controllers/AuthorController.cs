using API.Controllers;
using Interfaces.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.EntityServices;
using ViewModels.BookDtos;
using ViewModels;
using ViewModels.AuthorDtos;

namespace Web.API.Controllers
{
    public class AuthorController : BaseApiController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            this._authorService = authorService;
        }

        //[Authorize(Roles = "admin")]
        [AllowAnonymous]
        [HttpPost("AddAuthor")]
        public async Task<ActionResult<AuthorAddResponse>> AddAuthor(AuthorAddRequest authorAddRequest)
        {
            return await _authorService.AddAuthor(authorAddRequest);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetAuthorList")]
        public async Task<ActionResult<AuthorGetListResponse>> GetAuthorList()
        {
            return await _authorService.GetAuthorList();
        }

    }
}
