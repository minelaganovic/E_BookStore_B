using AutoMapper;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;
using MediatR;

namespace E_BookStore_B.Handlers
{
    public class GetAutorByIDHandler: IRequestHandler<GetAutorByIDQuery, AutorDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAutorByIDHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<AutorDTO> Handle(GetAutorByIDQuery request, CancellationToken cancellationToken)
        {
            var autors = await _uow.AutorRepository.GetAutorAsync(request.Id);
            if (autors == null)
            {
                return null;
            }
            return _mapper.Map<AutorDTO>(autors);
        }
    }
}

