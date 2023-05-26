using AutoMapper;
using Interfaces.ServicesInterfaces;
using Models.Classes;
using Repositories.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.AuthorDtos;

namespace Services.EntityServices
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            this._authorRepository = authorRepository;
            this._mapper = mapper;
        }

        public async Task<AuthorAddResponse> AddAuthor(AuthorAddRequest authorAddRequest)
        {
            if (!await _authorRepository.ExistsAsync(x => x.Name == authorAddRequest.Name && x.Family == authorAddRequest.Family))
            {
                await _authorRepository.AddAsync(_mapper.Map<Author>(authorAddRequest));
                await _authorRepository.SaveAllAsync();
                return (_mapper.Map<AuthorAddResponse>(authorAddRequest));
            }
            throw new Exception("Author has been exists");
        }

        public async Task<AuthorGetListResponse> GetAuthorList()
        {
            var list = await _authorRepository.GetList(x => x.Deleted == false);
            return new AuthorGetListResponse { authorList = _mapper.Map<List<AuthorResponse>>(list) };

        }
    }
}
