using System.ComponentModel.DataAnnotations;

namespace SharingFood.Models
{
    public class AccountsModel
    {
        [Key]
        public int entry { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public bool isMod { get; set; }
    }
}