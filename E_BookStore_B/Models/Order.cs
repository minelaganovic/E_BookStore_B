using System.ComponentModel.DataAnnotations;

namespace E_BookStore_B.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public int kolicina  { get; set; }
        public string adresa { get; set; }
        public string telefon { get; set; }
        public int user_id { get; set; }
        public int book_id { get; set; }
        public string status { get; set; }

    }
}
