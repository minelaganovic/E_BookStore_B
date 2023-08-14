using System.ComponentModel.DataAnnotations;

namespace E_BookStore_B.DTOs
{
    public class AutorDTO
    {
        [Required(ErrorMessage = "Polje je obavezno")]
        public int id { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public string ime { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public string adresa { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public string email { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public string websajt { get; set; }
    }
}
