using AutoMapper;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;
using MediatR;

namespace E_BookStore_B.Handlers
{
    public class GetAutorHandler : IRequestHandler<GetAutorQuery, List<AutorDTO>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAutorHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<AutorDTO>> Handle(GetAutorQuery request, CancellationToken cancellationToken)
        {
            var autori = await _uow.AutorRepository.GetAutorAsync();
            return _mapper.Map<List<AutorDTO>>(autori);
        }
    }
}
