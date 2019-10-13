using System.ComponentModel.DataAnnotations;
using Xamarin.Forms;

namespace SharingFood.Models
{
    public class PostsModel
    {
        [Key]
        public int entry { get; set; }
        public int account_entry { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
    }
}
