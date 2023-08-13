using AutoMapper;
using E_BookStore_B.Commands;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
using MediatR;

namespace E_BookStore_B.Handlers
{
    public class CreateBookHandler:IRequestHandler<CreateBookCommand,Book>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CreateBookHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request.bookDTO);
            _uow.BookRepository.AddBook(book);
            await _uow.SaveAsync();
            return book;
        }
    }
}
