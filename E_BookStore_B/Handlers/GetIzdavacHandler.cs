using AutoMapper;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;
using MediatR;

namespace E_BookStore_B.Handlers
{
    public class GetIzdavacHandler: IRequestHandler<GetIzdavacQuery, List<IzdavacDTO>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetIzdavacHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<IzdavacDTO>> Handle(GetIzdavacQuery request, CancellationToken cancellationToken)
        {
            var izdavac = await _uow.IzdavacRepository.GetIzdavacAsync();
            return _mapper.Map<List<IzdavacDTO>>(izdavac);
        }
    }
}
