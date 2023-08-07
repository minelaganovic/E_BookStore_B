using System.ComponentModel.DataAnnotations;

namespace E_BookStore_B.DTOs
{
    public class BookDTO
    {
        [Key]
        public int id { get; set; }
        public string naslov { get; set; }
        public int autor_id { get; set; }
        public int izdavac_id { get; set; }
        public string godina_izdanja { get; set; }
        public string izdanje { get; set; }
        public int cena { get; set; }
        public string jezik_publikacije { get; set; }
        public string ISBN { get; set; }
        public int kolicina { get; set; }
        public string tip_knjige { get; set; }
    }
}
