using System.ComponentModel.DataAnnotations;

namespace E_BookStore_B.DTOs
{
    public class BookDTO
    {
        [Key]
        [Required (ErrorMessage="Polje je obavezno")]
        public int id { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(20, MinimumLength=2)]
        [RegularExpression (".*[a-zA-Z]+.*", ErrorMessage ="Brojevi nisu dozvoljeni")]
        public string naslov { get; set; }

        [Required (ErrorMessage = "Polje je obavezno")]
        public int autor_id { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public int izdavac_id { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        //[StringLength(4, MinimumLength = 4)]
        public string godina_izdanja { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(20, MinimumLength = 6)]
        public string izdanje { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        //[StringLength(20, MinimumLength = 1)]
        public int cena { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public string jezik_publikacije { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(13, MinimumLength = 13)]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public int kolicina { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public string tip_knjige { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]

        public string sazetak { get; set; }

    }
}
