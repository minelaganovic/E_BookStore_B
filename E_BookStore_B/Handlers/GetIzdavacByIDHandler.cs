using AutoMapper;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;
using MediatR;

namespace E_BookStore_B.Handlers
{
    public class GetIzdavacByIDHandler: IRequestHandler<GetIzdavacByIDQuery, IzdavacDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetIzdavacByIDHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IzdavacDTO> Handle(GetIzdavacByIDQuery request, CancellationToken cancellationToken)
        {
            var izdavac = await _uow.IzdavacRepository.GetIzdavacAsync(request.Id);
            if (izdavac == null)
            {
                return null;
            }
            return _mapper.Map<IzdavacDTO>(izdavac);
        }
    }
}

