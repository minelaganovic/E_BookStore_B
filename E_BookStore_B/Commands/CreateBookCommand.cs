using E_BookStore_B.DTOs;
using E_BookStore_B.Models;
using MediatR;

namespace E_BookStore_B.Commands
{
    public class CreateBookCommand:IRequest<Book>
    {
        public BookDTO bookDTO { get; set; }

        public CreateBookCommand(BookDTO bookDTO)
        {
            this.bookDTO = bookDTO;
        }
    }
}
