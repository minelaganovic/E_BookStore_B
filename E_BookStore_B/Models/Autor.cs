using System.ComponentModel.DataAnnotations;

namespace E_BookStore_B.Models
{
    public class Autor
    {
        [Key]
        public int id { get; set; }
        public string ime { get; set; }
        public string adresa { get; set; }
        public string email { get; set; }
        public string websajt { get; set; }
    }
}
