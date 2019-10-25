using System.ComponentModel.DataAnnotations;

namespace SharingFood.Models
{
    public class AccountModel
    {
        [Key]
        public int entry { get; set; }
        public int user_entry { get; set; }
        public string email { get; set; }
        public bool isLogged { get; set; }
    }
}
