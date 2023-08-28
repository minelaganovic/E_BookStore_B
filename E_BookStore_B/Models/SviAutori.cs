using System.ComponentModel.DataAnnotations;

namespace E_BookStore_B.Models
{
    public class SviAutori
    {

        [Key]
        public int id { get; set; }
        public int book_id { get; set; }
        public int autor_id { get; set; }
    }
}
