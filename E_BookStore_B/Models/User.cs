using System.ComponentModel.DataAnnotations;

namespace E_BookStore_B.Models
{
    public class User
    {

        [Key]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string pwd { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
