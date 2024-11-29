using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.Models
{
    [Table("user1")]
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? password { get; set; }
    }
}
